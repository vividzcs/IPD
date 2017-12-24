using System;
using Utils;

namespace Class
{
    public partial class Class_Experiment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid(courseId)才能访问到的页面

            AuthHelper.LoginCheck(Session, Request, Response, Server);
            AuthHelper.StudentOnlyPage(Session, Request, Response, Server);
            var cidString = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}