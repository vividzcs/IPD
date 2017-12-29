using BusinessLogicLayer.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_CreateDepartment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       AuthHelper.LoginCheck(Session, Request, Response, Server);
       AuthHelper.AdminOnlyPage(Session, Request, Response, Server);
    }

    /*
     create department
         */
    protected void ButtonCreateDepartment_Click(object sender, EventArgs e)
    {
        Boolean fileOk = false;
        if (pic_upload.HasFile)//验证是否包含文件
        {
            //取得文件的扩展名,并转换成小写
            string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
            //验证上传文件是否图片格式
            fileOk = IsImage(fileExtension);


            if (fileOk)
            {
                string savePath = Server.MapPath("~/Images/");
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                var millisecond = DateTime.Now.Millisecond;
                pic_upload.SaveAs(savePath + millisecond + pic_upload.FileName);//保存图片
                                             
                //清空提示
                lbl_pic.Text = "";


                new DepartmentServiceImpl().CreateDepartment(new Department
                {
                    ChinesaeName = TextBoxName.Text,
                    EnglishName = TextBoxEnglishName.Text,
                    Introduction = TextAreaIntroduction.InnerText,
                    Image = savePath.Remove(0, Server.MapPath("~").Length - 1) + millisecond + pic_upload.FileName,
                });

            }
            else
            {
                lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
            }
        }
        else
        {
            lbl_pic.Text = "请选择要上传的图片！";
        }


        Response.Redirect("ManageDepartment.aspx");
    }
    
    
    public bool IsImage(string str)
    {
        bool isimage = false;
        string thestr = str.ToLower();
        //限定只能上传jpg和gif图片
        string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
        //对上传的文件的类型进行一个个匹对
        for (int i = 0; i < allowExtension.Length; i++)
        {
            if (thestr == allowExtension[i])
            {
                isimage = true;
                break;
            }
        }
        return isimage;
    }
}