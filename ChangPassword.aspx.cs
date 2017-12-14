using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Utils;

public partial class ChangPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var session = Session["user"];
        if (session == null)
        {
            Response.Redirect("~/Login.aspx");
            return;
        }
    }

    protected void ChangePasswordAction(object sender, EventArgs e)
    {
        //封装数据
        var session = Session["user"];
        switch (session)
        {
            case Student student:
                student.Password = Md5Helper.Md5WithSalt(new_password.Value);
                var s = new StudentServiceImpl().ModifyPassword(student);
                if (s == 1)
                {
                    Session.Remove("user");
                    Response.Redirect("Login.aspx");
                }
                break;
        }
    }
}