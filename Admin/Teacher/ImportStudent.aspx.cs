using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

public partial class ImportStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);

        if (Request["course"] == null)
        {
            Response.Redirect("CourseList.aspx");
        }
    }

    protected void import_ServerClick(object sender, EventArgs e)
    {
        var stuidstring = Request.Form.Get("stuid");
        var stunamestring = Request.Form.Get("stuname");
        var stuclassstring = Request.Form.Get("stuclass");

        var stuidlist = stuidstring.Split(',');
        var stunamelist = stunamestring.Split(',');
        var stuclasslist = stuclassstring.Split(',');
        //for(int i=0;i<stuidlist.Length;i++)
        //{
        //    int this_stuid = int.Parse(stuidlist[i]);
        //    var newcs = new CourseSelection() {
        //        CourseId = int.Parse(Request["course"]),
        //        StudentId = new StudentServiceImpl().GetByStudentNumber(stuidlist[i]).StudentId
        //    };
        //    int res = new CourseSelectionServiceImpl().CreateCourseSelectRecording(newcs);
        //    if(res == 1)
        //    {
        //        Response.Redirect("CourseList.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("ImportStudent.aspx");
        //    }
        //}
    }
}