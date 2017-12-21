<%@ WebHandler Language="C#" Class="UploadExperimentHandler" %>

using System;
using System.Web;
using Models;

public class UploadExperimentHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        try
        {
            CourseExperiment courseExperiment = new CourseExperiment()
            {
                Name = context.Request["ExperimentName"],
                Deadline = DateTime.Parse(context.Request["ExperimentDeadLine"]),
                Purpose = context.Request["ExperimentPurpose"].Replace("\n","<br/>"),
                Steps = context.Request["ExperimentSteps"].Replace("\n","<br/>"),
                References = context.Request["ExperimentReferences"].Replace("\n","<br/>"),
                CourseId = int.Parse(context.Request["CourseId"]),
                IssuedTime = DateTime.Now,
            };
            CourseExperimentServiceImpl courseExperimentServiceImpl = new CourseExperimentServiceImpl();
            if(courseExperimentServiceImpl.Create(courseExperiment) != 0)
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