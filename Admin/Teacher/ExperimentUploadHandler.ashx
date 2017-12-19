<%@ WebHandler Language="C#" Class="ExperimentUploadHandler" %>

using System;
using System.Web;
using Models;
using System.IO;

public class ExperimentUploadHandler : IHttpHandler ,System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        HttpPostedFile httpPostedFile = context.Request.Files["file"];

        if(httpPostedFile != null && httpPostedFile.FileName != "")
        {

            var savePath = context.Server.MapPath("~/TeacherUpload/CourseWare/") +
                                   ((Teacher)context.Session["user"]).JobNumber +
                                   "\\";
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            httpPostedFile.SaveAs(savePath + httpPostedFile.FileName);
            //开始入库
            int CourseId = int.Parse(context.Request.Form["CourseId"]);
            string FileName = httpPostedFile.FileName;
            string Path = "/TeacherUpload/CourseWare/" + ((Teacher)context.Session["user"]).JobNumber + "/" + FileName;
            CourseAttachment courseAttachment = new CourseAttachment()
            {
                CourseId = CourseId,
                Name = FileName,
                IssuedTime = DateTime.Now,
                Path = Path
            };

            CourseAttachmentServiceimpl serviceimpl = new CourseAttachmentServiceimpl();
            if(serviceimpl.Create(courseAttachment) != 0)
                context.Response.Write("{status:1,msg:'"+ httpPostedFile.FileName +"'}");
            else
                     context.Response.Write("{status:0,msg:'上传失败'}");
        }
        else
        {
            context.Response.Write("{status:0,msg:'上传失败'}");
        }





    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}