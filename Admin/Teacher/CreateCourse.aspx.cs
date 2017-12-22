using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections;
using System.IO;
using Utils;

public partial class Admin_CreateCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.AuthCheck(Session, Request, Response, Server);

        var all = new ClassServiceImpl().GetAll();

            DropDownList1.DataSource = all;  //绑定班级
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ClassId";
            DropDownList1.DataBind();
        ArrayList schoolYear = new ArrayList();  //绑定学年
        for(int i= DateTime.Now.Year;i>= DateTime.Now.Year-6;i--)
            schoolYear.Add( (i) + "-" + (i+1) );
        SchoolYear.DataSource = schoolYear;
        SchoolYear.DataBind();
        ArrayList semester = new ArrayList(new int[] { 1,2,3});
        Semester.DataSource = semester;
        Semester.DataBind();

    }
    
    protected void NextStep(object sender, EventArgs e)
    {
        try
        {
            Teacher teacher = (Teacher)Session["user"];
            var savePath = Request.MapPath("~/TeacherUpload/CourseImage/") +
                                       teacher.JobNumber +
                                       "\\";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            var millisecond = DateTime.Now.Millisecond;
            CourseImage.SaveAs(savePath + millisecond + CourseImage.FileName);
            string Path = "/TeacherUpload/CourseImage/" + teacher.JobNumber + "/" + millisecond + CourseImage.FileName;

            Course course = new Course()
            {
                Name = CourseName.Value,
                ShortIntroduction = ShortCourseIntro.Value,
                TeacherId = teacher.TeacherId,
                SchoolYear = SchoolYear.Text,
                Semester = Semester.Text,
                IntroImage = Path,
                ClassId = int.Parse(DropDownList1.SelectedValue)
            };
            //之后再验证数据

            CourseServiceImpl courseServiceImpl = new CourseServiceImpl();
            int id = courseServiceImpl.Create(course);

            Response.Redirect("IntroductionInDetail.aspx?id=" + id);
        }catch(Exception ex)
        {
            Label.Text = "填写错误";
        }

    }
}