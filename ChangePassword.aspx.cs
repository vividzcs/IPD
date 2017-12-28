using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //必须要登录了才能更改密码
        AuthHelper.LoginCheck(Session, Request, Response, Server);

//        SpanTipPassword.Visible = false;
//        SpanTipConfirmPassword.Visible = false;
    }

    protected void ChangePasswordAction(object sender, EventArgs e)
    {

        /*if (new_password.Value.Length == 0)
        {
            SpanTipPassword.Visible = true;
            return;
        }
        if (new_password.Value.Length < 6)
        {
            SpanTipPassword.Visible = true;
            SpanTipPassword.InnerText = "密码长度不够";
            return;
        }
        SpanTipPassword.Visible = false;

        if (renew_password.Value.Length == 0)
        {
            SpanTipConfirmPassword.Visible = true;
            return;
        }

        if (!new_password.Value.Equals(renew_password.Value))
        {
            SpanTipPassword.InnerText = "两次密码输入不一致";
            SpanTipPassword.Visible = true;
            return;
        }
        SpanTipPassword.Visible = false;*/


        //封装数据
        var session = Session["user"];
        switch (session)
        {
            case Student student:
                student.Password = Md5Helper.Md5WithSalt(new_password.Value);
                if (new StudentServiceImpl().ModifyPassword(student) == 1)
                {
                    //改密成功，清除session，要求重新登录
                    Session.RemoveAll();
                    Response.Redirect("/Login.aspx");
                }
                break;

            case Teacher teacher:
                teacher.Password = Md5Helper.Md5WithSalt(new_password.Value);
                if (new TeacherServiceImpl().ModifyPassword(teacher) == 1)
                {
                    //改密成功，清除session，要求重新登录
                    Session.RemoveAll();
                    Response.Redirect("/Login.aspx");
                }
                break;

            case Admin admin:
                admin.Password = Md5Helper.Md5WithSalt(new_password.Value);
                if (new AdminServiceImpl().ModifyPassword(admin) == 1)
                {
                    //改密成功，清除session，要求重新登录
                    Session.RemoveAll();
                    Response.Redirect("/Login.aspx");
                }
                break;


        }
    }
}