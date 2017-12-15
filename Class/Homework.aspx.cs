using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using BusinessLogicLayer.Impl;
using Models;

namespace Class
{
    public partial class Class_Homework : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid(courseId)才能访问到的页面
            var session = Session["user"];
            var cidString = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("/Default.aspx");
                return;
            }

            if (session == null)
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        protected void FileUpload(object sender, EventArgs e)
        {
            if (FileUploader.HasFile)
            {
                if (FileUploader.FileName.EndsWith(".doc", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".docx", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".ppt", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".pptx", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".7z", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".pdf", true, CultureInfo.CurrentCulture) ||
                    FileUploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture))
                {
                    var savePath = Server.MapPath("~/UserUploads/Homeworks/") +
                                   ((Student) Session["user"]).StudentNumber +
                                   "\\";
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    var millisecond = DateTime.Now.Millisecond;
                    FileUploader.SaveAs(savePath + millisecond + FileUploader.FileName);

                    var homework = new Homework()
                    {
                        Name = millisecond + FileUploader.FileName,
                        Path = savePath
                    };
                    var succeed = new HomeworkServiceImpl().Submit((CourseHomework) (Session["ThatCourseHomework"]),
                        (Student) (Session["user"]), homework);
                    Session.Remove("ThatCourseHomework");
                    Response.Write(succeed == 1
                        ? "<script>alert(\"上传成功！\");</script>"
                        : "<script>alert(\"上传失败请重试！\");</script>");
                }
                else
                {
                    Response.Write("<script>alert(\"不能上传的格式！\");</script>");
                }
            }
            else
            {
                Response.Write("<script>alert(\"请先选择文件再点击上传\");</script>");
            }
        }
    }
}