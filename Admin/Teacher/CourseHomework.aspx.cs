using System;
using Utils;

namespace Admin.Teacher
{
    public partial class Admin_CourseHomework : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录才能看到
            AuthHelper.LoginCheck(Session, Request, Response, Server);

            if (Session["user"] is Models.Teacher t)
            {
                //需要登录和cid(courseId)才能访问到的页面
                var cidString = Request.QueryString["course"];
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
        }
    }
}