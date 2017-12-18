using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Impl;
using Models;

public partial class Class_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ceid"] == null)
            Response.Redirect("Experiment.aspx");
    }

    protected void FileUpload(object sender, EventArgs e)
    {
        if (Uploader.HasFile)
        {
            if (Uploader.FileName.EndsWith(".doc", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".docx", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".ppt", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".pptx", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".7z", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".pdf", true, CultureInfo.CurrentCulture) ||
                Uploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture))
            {
                var savePath = Server.MapPath("~/UserUploads/Experiments/") +
                               ((Student) Session["user"]).StudentNumber +
                               "\\";
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                var millisecond = DateTime.Now.Millisecond;
                Uploader.SaveAs(savePath + millisecond + Uploader.FileName);

                var experiment = new Experiment()
                {
                    Name = millisecond + Uploader.FileName,
                    Path = savePath
                };

                //由ceid获得courseExperiment
                var ceid = 0;
                if (Request.QueryString["ceid"] != null)
                {
                    ceid = int.Parse(Request.QueryString["ceid"]);
                }

                var succeed = new ExperimentServiceImpl().Submit(
                    (CourseExperiment) (Session["ThatCourseExperiment" + ceid]),
                    (Student) (Session["user"]), experiment);
                Session.Remove("ThatCourseExperiment" + ceid);
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