﻿using System;

namespace Class
{
    public partial class Attachment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //需要登录和cid才能访问到的页面
            var session = Session["user"];
            var cidString = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("/Default.aspx");
                return;
            }

            if (session == null || string.IsNullOrEmpty(cidString))
            {
                Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                return;
            }
        }
    }
}