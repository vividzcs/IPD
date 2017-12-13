using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void LoginAction(object sender, EventArgs e)
    {
        switch (Username.Value.Length)
        {
            case 3:
            {
                //是管理员在登录

                //封装数据
                var a = new Admin()
                {
                    Password = Password.Value,
                    JobNumber = Username.Value
                };

                //调用业务逻辑
                var admin = new AdminServiceImpl().Login(a);

                //处理数据转发
                if (admin != null)
                {
                    Session["user"] = admin;
                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    InconsistentTip.Visible = true;
                }
                break;
            }
            case 10:
            {
                //是学生在登录

                //封装数据
                var s = new Student()
                {
                    Password = Password.Value,
                    StudentNumber = Username.Value
                };

                //调用业务逻辑
                var student = new StudentServiceImpl().Login(s);

                //处理数据转发
                if (student != null)
                {
                    Session["user"] = student;
                    Response.Redirect("~/Student/Home.aspx");
                }
                else
                {
                    InconsistentTip.Visible = true;
                }
                break;
            }
            default:
                if (Username.Value.Length == 10)
                {
                    //是老师在登录

                    //封装数据
                    var t = new Teacher()
                    {
                        Password = Password.Value,
                        JobNumber = Username.Value
                    };

                    //调用业务逻辑
                    var teacher = new TeacherServiceImpl().Login(t);

                    //处理数据转发
                    if (teacher != null)
                    {
                        Session["user"] = teacher;
                        Response.Redirect("TeacherHome.aspx");
                    }
                    else
                    {
                        InconsistentTip.Visible = true;
                    }
                }
                break;
        }
    }
}