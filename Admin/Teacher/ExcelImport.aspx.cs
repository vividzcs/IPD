using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Utils;

public partial class Admin_Teacher_ExcelImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

        if (Request.QueryString["course"] == null)
        {
            Response.Redirect("CourseList.aspx");
        }
    }

    protected void ExcelUpload(object sender, EventArgs e)
    {
        //确保上传的有文件且文件是excel格式！
        if ((!Uploader.HasFile || Uploader.PostedFile.ContentType != "application/vnd.ms-excel") &&
            Uploader.PostedFile.ContentType !=
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") return;
        try
        {
            //把文件放到TeacherUpload/StudentExcelList目录下
            string fileName = Path.Combine(Server.MapPath("~/TeacherUpload/StudentExcelList"),
                Guid.NewGuid() + Path.GetExtension(Uploader.PostedFile.FileName));
            Uploader.PostedFile.SaveAs(fileName);

            //创建excel访问的数据源
            string conString = "";
            string ext = Path.GetExtension(Uploader.PostedFile.FileName);
            if (ext.ToLower() == ".xls")
            {
                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                            ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (ext.ToLower() == ".xlsx")
            {
                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
                            ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            //按照数据源使用SQL语句查询excel条目
            string query =
                "Select [姓名],[学号] from [Sheet1$]";
            OleDbConnection con = new OleDbConnection(conString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Close();
            con.Dispose();

            //利用LINQ语句把查出来的学生放在sList列表中
            var sList = (from DataRow dr in ds.Tables[0].Rows
                let name = dr["姓名"].ToString()
                let studentNumber = dr["学号"].ToString()
                select new Student()
                {
                    Name = name,
                    StudentNumber = studentNumber
                }).ToList();

            //拿到URL里面传过来的courseid
            var courseId = int.Parse(Request.QueryString["course"]);

            //通过courseId和学生id创建学生的选课关系CourseSelection对象，并把CourseSelection返回值放在courseSelections变量里面，下面用
            //学生id通过学号拿到
            var courseSelections = sList.Select(student => new StudentServiceImpl().GetByStudentNumber(student.StudentNumber))
                .Select(s => new CourseSelectionServiceImpl().CreateCourseSelectRecording(new CourseSelection()
                {
                    StudentId = s.StudentId,
                    CourseId = courseId
                }))
                .ToList();

            //输出添加成功的条目数
            Response.Write("<script>alert(\"成功添加" + courseSelections.Count + "名学生到该课程！\");window.close();</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(\"添加失败，失败信息: "+ex.Message+"\");window.close();</script>");
        }
    }
}