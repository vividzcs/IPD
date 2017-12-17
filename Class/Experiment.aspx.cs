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

        protected void FileUpload(object sender, EventArgs e)
        {
            if (ExperimentUploader.HasFile)
            {
                if (ExperimentUploader.FileName.EndsWith(".doc", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".docx", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".ppt", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".pptx", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".7z", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".pdf", true, CultureInfo.CurrentCulture) ||
                    ExperimentUploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture))
                {
                    var savePath = Server.MapPath("~/UserUploads/Experiments/") +
                                   ((Student)Session["user"]).StudentNumber +
                                   "\\";
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    var millisecond = DateTime.Now.Millisecond;
                    ExperimentUploader.SaveAs(savePath + millisecond + ExperimentUploader.FileName);

                    var experiment = new Experiment()
                    {
                        Name = millisecond + ExperimentUploader.FileName,
                        Path = savePath
                    };
                    var succeed = new ExperimentServiceImpl().Submit((CourseExperiment)(Session["ThatCourseExperiment"]),
                        (Student)(Session["user"]), experiment);
                    Session.Remove("ThatCourseExperiment");
                    Response.Write(succeed == 1
                        ? "<script>alert(\"上传成功！\");</script>"
                        : "<script>alert(\"上传失败请重试！\");</script>");
                }
                else
                {
                    Response.Write("<script>alert(\"不能上传的格式！\");</script>");
                }
            }
            else
            {
                Response.Write("<script>alert(\"请先选择文件再点击上传\");</script>");
            }
        }
    }
}