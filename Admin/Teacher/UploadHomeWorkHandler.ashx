<%@ WebHandler Language="C#" Class="UploadHomeWorkHandler" %>

using System;
using System.Web;
using Models;

public class UploadHomeWorkHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        // 
        try
        {
            CourseHomework courseHomework = new CourseHomework()
            {
                Name = context.Request["HomeWorkName"],
                Deadline = DateTime.Parse(context.Request["HomeDeadline"]),
                Content = context.Request["HomeWorkContent"].Replace("\n","<br/>"),
                CourseId = int.Parse(context.Request["CourseId"]),
                IssuedTime = DateTime.Now,
            };

            CourseHomeworkServiceImpl courseHomeworkServiceImpl = new CourseHomeworkServiceImpl();
            if(courseHomeworkServiceImpl.Create(courseHomework) != 0)
                context.Response.Write("{status:1,msg:'上传成功'}");
            else
                context.Response.Write("{status:0,msg:'上传失败'}");
        }catch(Exception e)
        {
                 context.Response.Write("{status:0,msg:'格式有误'}");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}