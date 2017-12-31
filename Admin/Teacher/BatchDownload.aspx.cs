using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using ICSharpCode.SharpZipLib.Zip;
using Utils;

public partial class Admin_Teacher_BatchDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.LoginCheck(Session, Request, Response, Server);
        AuthHelper.TeacherOnlyPage(Session, Request, Response, Server);

        if (Request.QueryString["pt"] == null || Request.QueryString["id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        string pageType = Request.QueryString["pt"];
        int id = int.Parse(Request.QueryString["id"]);

        if (pageType == "ho")
        {
            var service = new HomeworkServiceImpl();
            var homeworks = service.GetHomeworkByCourseHomeworkId(id);

            var downloadUrLs = homeworks.Aggregate("",
                (current, homework) => current + ("http://" + Request.Url.Host + homework.Path + Environment.NewLine));
            downloadUrLs = downloadUrLs.Replace("\\", "/");
            Response.Write(downloadUrLs);

            var path = homeworks.Select(homework => homework.Path).ToList();


            var buffer = Download(path.ToArray());
            if (buffer != null)
            {
                Response.Clear();
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
                Response.BinaryWrite(buffer); //输出
                Response.Flush();
                Response.End();
            }

            /*var command = "7z a homework.zip ";
            foreach (var homework in homeworks)
            {
                command = command + "\"" + homework.Path + "\"" + " ";
            }*/


            /*Process process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = command.Replace("\\", "")
                }
            };
            process.Start();
            process.WaitForExit();
            string output = "";
            if (process.HasExited)
            {
                output = process.StandardOutput.ReadToEnd();
            }

            Response.Write(File.Exists("~/homework.zip"));
            Response.Write(output);*/
        }
        else if (pageType == "ex")
        {
            var service = new ExperimentServiceImpl();
            var experiments = service.GetExpermentByCourseExperimentId(id);

            var downloadUrLs = experiments.Aggregate("",
                (current, experiment) =>
                    current + ("http://" + Request.Url.Host + experiment.Path + Environment.NewLine));
            downloadUrLs = downloadUrLs.Replace("\\", "/");
            Response.Write(downloadUrLs);

            var path = experiments.Select(homework => homework.Path).ToList();


            var buffer = Download(path.ToArray());
            if (buffer != null)
            {
                Response.Clear();
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
                Response.BinaryWrite(buffer); //输出
                Response.Flush();
                Response.End();
            }
        }
    }

    ///批量下载
    ///参数string[]数组，需要传物理路径
    ///返回值byte[]数组
    public byte[] Download(string[] path)
    {
        byte[] buffer = null;
        using (MemoryStream ms = new MemoryStream())
        {
            using (ZipFile zip = ZipFile.Create(ms))
            {
                zip.BeginUpdate();
                zip.NameTransform = new MyNameTranform(); //使用自定义MyNameTranform类，改变打包路径

                if (path.Length == 0)
                {
                    Response.Write("<script>alert(\"没有人交了这个作业\");</script>");
                    return null;
                }

                //遍历path放入zip中
                foreach (var p in path)
                {
                    zip.Add(Server.MapPath("~") + p);
                }
                try
                {
                    zip.CommitUpdate();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(\"打包出错，请联系管理员，错误信息：\" " + ex.Message + ");</script>");
                }
                buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length); //读入buffer
            }
        }

        return buffer;
    }
}

///修改打包路径，仅需要文件名和扩展名即可
public class MyNameTranform : ICSharpCode.SharpZipLib.Core.INameTransform
{
    public string TransformDirectory(string name)
    {
        return null;
    }

    ///返回文件名和扩展名
    public string TransformFile(string name)
    {
        return Path.GetFileName(name);
    }
}