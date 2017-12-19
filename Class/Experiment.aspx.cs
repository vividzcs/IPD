using System;
using System.Linq;
using BusinessLogicLayer.Impl;
using Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;

namespace Class
{
    public partial class Class_Experiment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid(courseId)才能访问到的页面
            var session = Session["user"];
            var cidString = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("/Default.aspx");
                return;
            }

            if (session == null)
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        
    }
}