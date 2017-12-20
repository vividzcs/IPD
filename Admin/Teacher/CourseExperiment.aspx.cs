using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CourseExperiment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //需要登录才能看到
        var session = Session["user"];
        if (session == null)
        {
            //没有登录转到登录界面
            Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            return;
        }
        var teacher = new Models.Teacher();
        if (session is Models.Teacher t)
        {
            teacher = t;
            //需要登录和cid(courseId)才能访问到的页面
            //var cidString = Request.QueryString["cid"];
            var cidString = "3";
            if (string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("/Default.aspx");
                return;
            }
        }
        else
        {
            //登录的不是老师，转到登录界面
            Session.Remove("user");
            Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            return;
        }


    }
}