using System;
using Models;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Utils;
using System.Collections;
using System.IO;

public partial class Admin_Teacher_EditCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);

        if(!IsPostBack)
        {
            var all = new ClassServiceImpl().GetAll();

            DropDownList1.DataSource = all;  //绑定班级
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ClassId";
            DropDownList1.DataBind();
            ArrayList schoolYear = new ArrayList();  //绑定学年
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 6; i--)
                schoolYear.Add((i) + "-" + (i + 1));
            SchoolYear.DataSource = schoolYear;
            SchoolYear.DataBind();
            ArrayList semester = new ArrayList(new int[] { 1, 2, 3 });
            Semester.DataSource = semester;
            Semester.DataBind();

            if (Request.QueryString["id"] != null)
            {
                int CourseId = int.Parse(Request.QueryString["id"]);
                CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
                Course course = (Course)courseServiceImpl.GetById(CourseId);
                //绑定数据
                CourseName.Value = course.Name;
                DropDownList1.Text = string.Concat(course.ClassId);
                SchoolYear.Text = course.SchoolYear;
                Semester.Text = course.Semester;
                ShortCourseIntro.Value = course.ShortIntroduction;
            }
        }
        
    }

    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            Teacher teacher = (Teacher)Session["user"];
            string Path = null;
            if (CourseImage.PostedFile != null && CourseImage.PostedFile.FileName != "")
            {
                var savePath = Request.MapPath("~/TeacherUpload/CourseImage/") +
                                       teacher.JobNumber +
                                       "\\";
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                var millisecond = DateTime.Now.Millisecond;
                CourseImage.SaveAs(savePath + millisecond + CourseImage.FileName);
                Path = "/TeacherUpload/CourseImage/" + teacher.JobNumber + "/" + millisecond + CourseImage.FileName;

            }


            int CourseId = int.Parse(Request.QueryString["id"]);
            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            Course course = (Course)courseServiceImpl.GetById(CourseId);
            course.Name = CourseName.Value;
            course.ShortIntroduction = ShortCourseIntro.Value;
            course.TeacherId = teacher.TeacherId;
            course.SchoolYear = SchoolYear.Text;
            course.Semester = Semester.Text;
            course.IntroImage = Path == null ? null : Path;
            course.ClassId = int.Parse(DropDownList1.Text);
            //之后再验证数据

            course = (Course)courseServiceImpl.Modify(course);

            Response.Redirect("EditIntroDetail.aspx?id=" + course.CourseId);
        }
        catch (Exception ex)
        {
            Label.Text = "填写错误";
        }
    }
}