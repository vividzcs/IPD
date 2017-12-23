using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

public partial class Admin_Teacher_ExcelImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.AuthCheck(Session, Request, Response, Server);
    }

    protected void ExcelUpload(object sender, EventArgs e)
    {
        if ((!Uploader.HasFile || Uploader.PostedFile.ContentType != "application/vnd.ms-excel") &&
            Uploader.PostedFile.ContentType !=
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") return;
        try
        {
            string fileName = Path.Combine(Server.MapPath("~/TeacherUpload/StudentExcelList"),
                Guid.NewGuid() + Path.GetExtension(Uploader.PostedFile.FileName));
            Uploader.PostedFile.SaveAs(fileName);

            string conString = "";
            string ext = Path.GetExtension(Uploader.PostedFile.FileName);
            if (ext.ToLower() == ".xls")
            {
                conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                            ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (ext.ToLower() == ".xlsx")
            {
                conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
                            ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            string query =
                "Select [姓名],[学号] from [StudentData$]";
            OleDbConnection con = new OleDbConnection(conString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Close();
            con.Dispose();

            Response.Write(ds.Tables[0].Rows[0]);

            // Import to Database
            /*using (MuDatabaseEntities dc = new MuDatabaseEntities())
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string empID = dr["Employee ID"].ToString();
                    var v = dc.EmployeeMasters.Where(a => a.EmployeeID.Equals(empID)).FirstOrDefault();
                    if (v != null)
                    {
                        // Update here
                        v.CompanyName = dr["Company Name"].ToString();
                        v.ContactName = dr["Contact Name"].ToString();
                        v.ContactTitle = dr["Contact Title"].ToString();
                        v.EmployeeAddress = dr["Employee Address"].ToString();
                        v.PostalCode = dr["Postal Code"].ToString();
                    }
                    else
                    {
                        // Insert
                        dc.EmployeeMasters.Add(new EmployeeMaster
                        {
                            EmployeeID = dr["Employee ID"].ToString(),
                            CompanyName = dr["Company Name"].ToString(),
                            ContactName = dr["Contact Name"].ToString(),
                            ContactTitle = dr["Contact Title"].ToString(),
                            EmployeeAddress = dr["Employee Address"].ToString(),
                            PostalCode = dr["Postal Code"].ToString()
                        });
                    }
                }

                dc.SaveChanges();
            }*/
        }
        catch (Exception)
        {
            throw;
        }
    }
}