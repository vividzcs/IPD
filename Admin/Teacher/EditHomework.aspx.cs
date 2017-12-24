using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Teacher_EditHomework : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void NextStep(object sender, EventArgs e)
    {
        Response.Redirect("CourseList.aspx");
    }
}