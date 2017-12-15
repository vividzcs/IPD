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
    /// <summary>
    /// 所有用户的修改密码都在这里
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //必须要登录了才能更改密码
        var session = Session["user"];
        if (session != null) return;
        Response.Redirect("~/Login.aspx?pre=" + Server.UrlEncode(Request.Url.AbsoluteUri));
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
                    //改密成功，清除session，要求重新登录
                    Session.Remove("user");
                    Response.Redirect("/Login.aspx");
                }
                break;
        }
    }
}