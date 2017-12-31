using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Impl;
using Models;
using Utils;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
namespace Admin.Teacher
{
    public partial class Admin_CourseAttachment : System.Web.UI.Page
    {
        public IEnumerable<CourseAttachment> thisTeacherAttachment;
        protected void Page_Load(object sender, EventArgs e)
        {

            //需要登录才能看到
            AuthHelper.LoginCheck(Session, Request, Response, Server);
            AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

            var teacher = new Models.Teacher();
            string cidString = "";
            if (Session["user"] is Models.Teacher t)
            {
                teacher = t;
                //需要登录和cid(courseId)才能访问到的页面
                cidString = Request.QueryString["course"];
                if (string.IsNullOrEmpty(cidString))
                {
                    Response.Redirect("/Default.aspx");
                }
            }
            else
            {
                //登录的不是老师，转到登录界面
                Session.Remove("user");
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }


            var courseAttachment = new CourseAttachmentServiceimpl();
            var teacherCourse = new CourseServiceImpl();
            //获得当前老师教的课程
            var nowCourse = new CourseServiceImpl().GetByCourseId(int.Parse(cidString));
            var nowAttachment = courseAttachment.Get(nowCourse);
            thisTeacherAttachment = nowAttachment;
            //var nowAttachment_id =((CourseAttachment)thisTeacherAttachment).AttachmentId;
            try
            {
                //通过js修改表单中提交的值，然后遍历正则找到 xxneededdeleted
                string pattern = @"\d{1,}neededdeleted";
                int neededDeleteAttachmentId;
                for (int i = 0; i < Request.Form.Count; i++)
                {
                    if (Regex.IsMatch(Request.Form.Keys[i], pattern))
                    {
                        neededDeleteAttachmentId = int.Parse(Request.Form.Keys[i].ToString().Split('n')[0]);
                        var deletePath = new CourseAttachmentServiceimpl().GetByAttachmentId(neededDeleteAttachmentId);
                        if (new CourseAttachmentServiceimpl().DeleteByAttachemtId(neededDeleteAttachmentId))
                        {
                            //删除数据库成功
                            //删除当前目录下文件
                            var temp = Server.MapPath("~" + deletePath.Path);
                            FileInfo file = new FileInfo(temp);//指定文件路径
                            try//判断文件是否存在
                            {

                                //file.Attributes = FileAttributes.Normal;//将文件属性设置为普通,比方说只读文件设置为普通
                                file.Delete();//删除文件
                                Response.Write("<script language='javascript'>alert('删除成功！请按F5刷新');</script>");
                                //Response.Redirect(Request.Url.ToString());
                            }
                            catch (Exception ex)
                            { }
                            finally
                            {
                                Response.Redirect(Request.Url.ToString());
                            }
                            Response.Redirect(Request.Url.ToString());

                        }
                        else
                        {
                            //删除失败
                            Response.Write("<script language='javascript'>alert('删除失败！请重试');window.location.reload();</script>");
                        }
                    }
                }
                

            }
            catch (Exception)
            {
                //没有提交表单不做处理
                //Console.Write("...");
            }

        }
        //上传课件代码
        protected void UploadCourseAttachment_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            string savePath = @"/TeacherUpload/CourseWare/";//此处savePath未加入，应该填入相应路径
            string teacherJobNum = "";
            if (Session["user"] is Models.Teacher t)
            {
                teacherJobNum = t.JobNumber;
                if (FileUploadCourseAttachment.HasFile)
                {

                    //上传到服务器文件夹中
                    String filename;
                    filename = FileUploadCourseAttachment.FileName;
                    //存储路径为当前路径+老师工号
                    string webSavePath = Server.MapPath("~" + savePath + "/" + teacherJobNum + "/" + filename);
                    if (!Directory.Exists(Server.MapPath("~" + savePath + "/" + teacherJobNum + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~" + savePath + "/" + teacherJobNum + "/"));
                    }
                    FileUploadCourseAttachment.SaveAs(webSavePath);

                    //插入到数据库中
                    var neededInsertCourseAttachment = new CourseAttachment();
                    neededInsertCourseAttachment.Name = filename;
                    //通过session获得课程id
                    string cidString = Request.QueryString["course"];
                    neededInsertCourseAttachment.CourseId = int.Parse(cidString);
                    neededInsertCourseAttachment.Path = savePath + teacherJobNum + "/" +filename;
                    neededInsertCourseAttachment.IssuedTime = DateTime.Now.ToLocalTime();
                    if (new CourseAttachmentServiceimpl().Create(neededInsertCourseAttachment) > 0)
                    {
                        
                        Response.Redirect(Request.Url.ToString());
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('上传失败，请重试！');</script>");
                    }

                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('上传失败，请重试！');</script>");
            }
        }
    }
}