using System;
using System.Globalization;
using System.IO;
using BusinessLogicLayer.Impl;
using Models;

public partial class Class_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void FileUpload(object sender, EventArgs e)
    {
        if (!Uploader.HasFile)
        {
            Response.Write("<script>alert(\"请先选择文件再点击上传\");</script>");
        }
        else
        {
            if (!(Uploader.FileName.EndsWith(".doc", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".docx", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".ppt", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".pptx", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".7z", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".tar.gz", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".pdf", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".cvs", true, CultureInfo.CurrentCulture) ||
                  Uploader.FileName.EndsWith(".zip", true, CultureInfo.CurrentCulture)))
            {
                Response.Write("<script>alert(\"不能上传的格式！\");</script>");
            }
            else
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

                var succeed = 0;
                if (Request.QueryString["ceid"] != null)
                {
                    var experiment = new Experiment()
                    {
                        Name = millisecond + Uploader.FileName,
                        Path = savePath.Remove(0, Server.MapPath("~").Length - 1)
                    };

                    //由ceid获得courseExperiment

                    var ceid = int.Parse(Request.QueryString["ceid"]);

                    succeed = new ExperimentServiceImpl().Submit(
                        (CourseExperiment) (Session["ThatCourseExperiment" + ceid]),
                        (Student) (Session["user"]), experiment);
                    Session.Remove("ThatCourseExperiment" + ceid);
                }
                else if (Request.QueryString["chid"] != null)
                {
                    var homework = new Homework()
                    {
                        Name = millisecond + Uploader.FileName,
                        Path = savePath.Remove(0, Server.MapPath("~").Length - 1)
                    };

                    //由ceid获得courseExperiment

                    var chid = int.Parse(Request.QueryString["chid"]);

                    succeed = new HomeworkServiceImpl().Submit(
                        (CourseHomework) (Session["ThatCourseHomework" + chid]),
                        (Student) (Session["user"]), homework);
                    Session.Remove("ThatCourseExperiment" + chid);
                }
                else
                {
                    Response.Write("<script>出现异常</script>");
                }

                Response.Write(succeed == 1
                    ? "<script>alert(\"上传成功！\");window.close();opener.location.reload();</script>"
                    : "<script>alert(\"上传失败请重试！\");</script>");
            }
        }
    }
}