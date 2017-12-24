﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Teacher_EditExperiment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
    }

    protected void StepOver(object sender, EventArgs e)
    {


        Response.Redirect("EditHomework.aspx?id=" + Request.QueryString["id"]);

    }

    protected void NextStep(object sender, EventArgs e)
    {
        Response.Redirect("EditHomework.aspx?id=" + Request.QueryString["id"]);
    }
}