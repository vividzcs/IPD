using System;
using Models;
using System.Linq;
using System.Web;
using System.IO;
using BusinessLogicLayer.Impl;
using Utils;

public partial class Admin_Teacher_DeletePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

        // 如果删除的是实验
        if (Request["ex"] != null)
        {
            using (var context = new HaermsEntities())
            {
                int exid = -1;
                try
                {
                    exid = int.Parse(Request["ex"]);
                }
                catch
                {
                    Response.Redirect("ManageCourseHwEx.aspx");
                }
                if(exid < 0)
                {
                    Response.Redirect("ManageCourseHwEx.aspx");
                }
                var queryset = context.Experiment.Where(ex => ex.ExperimentId == exid);
                if (queryset.FirstOrDefault() != null)
                {
                    try
                    {
                        string SuffixString = queryset.FirstOrDefault().Path;
                        string FinallPath = HttpContext.Current.Request.PhysicalApplicationPath + SuffixString.Remove(0, 1);
                        // 修改绝对路径，删除路径的磁盘标识必须是小写，例如"c:\User\README.md"
                        String c = FinallPath.Substring(0, 1);
                        FinallPath.Remove(0, 1);
                        FinallPath.Insert(0, c.ToLower());
                        FileAttributes attr = File.GetAttributes(FinallPath);
                        // 判断路径类型是文件夹还是文件
                        if (attr != FileAttributes.Directory)
                        {
                            // 如果是文件
                            File.Delete(FinallPath);
                            context.Experiment.Remove(queryset.FirstOrDefault());
                            context.SaveChanges();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        else if (Request["ho"] != null)
        {
            int hoid = -1;
            try
            {
                hoid = int.Parse(Request["ho"]);
            }
            catch
            {
                Response.Redirect("ManageCourseHwEx.aspx");
            }
            if (hoid < 0)
            {
                Response.Redirect("ManageCourseHwEx.aspx");
            }
            using (var context = new HaermsEntities())
            {
                var queryset = context.Homework.Where(ho => ho.HomeworkId == hoid);
                if (queryset.FirstOrDefault() != null)
                {
                    string SuffixString = queryset.FirstOrDefault().Path;
                    string FinallPath = HttpContext.Current.Request.PhysicalApplicationPath + SuffixString.Remove(0, 1);
                    String c = FinallPath.Substring(0, 1);
                    FinallPath.Remove(0, 1);
                    FinallPath.Insert(0, c.ToLower());
                    try
                    {
                        FileAttributes attr = File.GetAttributes(FinallPath);
                        if (attr != FileAttributes.Directory)
                        {
                            File.Delete(FinallPath);
                            context.Homework.Remove(queryset.FirstOrDefault());
                            context.SaveChanges();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        Response.Redirect("ManageCourseHwEx.aspx");
    }
}
