using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Teacher_EditCourseWare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck
    }

    protected void StepOver(object sender, EventArgs e)
    {


        Response.Redirect("EditExperiment.aspx?id=" + Request.QueryString["id"]);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        Response.Redirect("EditExperiment.aspx?id=" + Request.QueryString["id"]);
    }
}