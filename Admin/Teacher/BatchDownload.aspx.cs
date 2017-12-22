using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;

public partial class Admin_Teacher_BatchDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        }else if (pageType == "ex")
        {
            var service = new ExperimentServiceImpl();
            var experiments = service.GetExpermentByCourseExperimentId(id);

            var downloadUrLs = experiments.Aggregate("",
                (current, experiment) => current + ("http://" + Request.Url.Host + experiment.Path + Environment.NewLine));
            downloadUrLs = downloadUrLs.Replace("\\", "/");
            Response.Write(downloadUrLs);

        }
    }
}