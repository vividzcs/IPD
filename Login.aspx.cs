using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;
using Utils;

/// <summary>
/// 所有用户包括学生，管理员和教师的登录都在这里处理
/// </summary>
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
                    Password = Md5Helper.Md5WithSalt(Password.Value),
                    JobNumber = Username.Value
                };

                //调用业务逻辑
                var admin = new AdminServiceImpl().Login(a);

                //处理数据转发
                if (admin != null)
                {
                    Session["user"] = admin;
                    if (string.IsNullOrEmpty(Request.QueryString["pre"]))
                    {
                        Response.Redirect("~/Admin/Admin/ManageTeacher.aspx");
                    }
                    else
                    {
                        Response.Redirect(Server.UrlDecode(Request.QueryString["pre"]));
                    }
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
                    Password = Md5Helper.Md5WithSalt(Password.Value),
                    StudentNumber = Username.Value
                };

                //调用业务逻辑
                var student = new StudentServiceImpl().Login(s);

                //处理数据转发
                if (student != null)
                {
                    Session["user"] = student;

                    if (string.IsNullOrEmpty(Request.QueryString["pre"]))
                    {
                        Response.Redirect("/Student/Home.aspx");
                    }
                    else
                    {
                        Response.Redirect(Server.UrlDecode(Request.QueryString["pre"]));
                    }
                }
                else
                {
                    InconsistentTip.Visible = true;
                }
                break;
            }
            case 8:
                //是老师在登录

                //封装数据
                var t = new Teacher()
                {
                    Password = Md5Helper.Md5WithSalt(Password.Value),
                    JobNumber = Username.Value
                };

                //调用业务逻辑
                var teacher = new TeacherServiceImpl().Login(t);

                //处理数据转发
                if (teacher != null)
                {
                    Session["user"] = teacher;
                    if (string.IsNullOrEmpty(Request.QueryString["pre"]))
                    {
                        Response.Redirect("/Admin/Teacher/CourseList.aspx");
                    }
                    else
                    {
                        Response.Redirect(Server.UrlDecode(Request.QueryString["pre"]));
                    }
                }
                else
                {
                    InconsistentTip.Visible = true;
                }

                break;
            default:
                InconsistentTip.Visible = true;
                InconsistentTip.InnerText = "用户名长度不正确";
                break;
        }
    }
}