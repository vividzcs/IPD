using System;
using Utils;

public partial class Admin_Teacher_EditHomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
    }

    protected void NextStep(object sender, EventArgs e)
    {
        Response.Redirect("CourseList.aspx");
    }
}