using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GSUKariyer.COMMON;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using GSUKariyer.BUS;

public partial class UC_Users_uUsersImport : BaseUserControl
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrangeForm();
        }
    }

    protected void ArrangeForm()
    {
        string lastUploadedFile=SiteParams.GetLastUploadedExcelFile();

        if (string.IsNullOrEmpty(lastUploadedFile))
        {
            hLinkUploadFile.Visible=false;
        }
        else
        {
            hLinkUploadFile.Visible=true;
            hLinkUploadFile.NavigateUrl =String.Concat("~/", lastUploadedFile.Replace(Request.PhysicalApplicationPath, String.Empty).Replace("\\", "/"));
        }        
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuUserList.HasFile)
            {
                string fileNameWithoutExtention = String.Empty;
                string fileExtention = String.Empty;

                FileHelper.GetFileParts(fuUserList.FileName, ref fileNameWithoutExtention, ref fileExtention);

                if (fuUserList.FileBytes.Length > Config(EnumUtil.Config.MaxKB).ToInt())
                {
                    ErrorOccured(String.Format("Yüklemeye çalıştığınız dosya maksimum dosya boyutu olan {0} KB değerini aşmaktadır.!", Config(EnumUtil.Config.MaxKB)));
                    return;
                }

                if (FileHelper.HasRightFileExtention(fileExtention, "xls,xlsx"))
                {
                    DataTable dtUsers = UserEmails.CreateTable();

                    //Upload File
                    string uploadPath = String.Concat(Request.PhysicalApplicationPath,
                        Config(EnumUtil.Config.UserImportsUploadFolder), @"\");

                    string fileVersionedName = FileHelper.AddVersionToFileName(uploadPath, String.Concat(fileNameWithoutExtention, ".",
                        fileExtention));

                    uploadPath = String.Concat(uploadPath, fileVersionedName);

                    fuUserList.SaveAs(uploadPath);

                    //Read File
                    FileInfo fileInfo = new FileInfo(uploadPath);

                    using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                    {
                        var worksheet = excelPackage.Workbook.Worksheets[1];

                        int rowNo = 2;
                        while (!String.IsNullOrEmpty(worksheet.Cell(rowNo, 1).Value))
                        {
                            DataRow dr = dtUsers.NewRow();
                            dr[UserEmails.ColumnNames.StudentNumber] = worksheet.Cell(rowNo, 1).Value;
                            dr[UserEmails.ColumnNames.Email] = worksheet.Cell(rowNo, 2).Value;

                            int length=dr[UserEmails.ColumnNames.StudentNumber].ToString().Length;
                            for (int i = 0;i < (8 - length);i++)
                            {
                                dr[UserEmails.ColumnNames.StudentNumber] = String.Concat( 
                                    "0",
                                    dr[UserEmails.ColumnNames.StudentNumber].ToString());
                            }

                            dtUsers.Rows.Add(dr);
                            rowNo++;
                        }
                    }

                    UserEmails.Import(dtUsers,uploadPath);

                    //DeleteFiles - Do not delete files
                    //File.Delete(uploadPath);

                    Success(String.Format("{0} kayıt başarıyla eklenmiştir.",dtUsers.Rows.Count.ToString()));
                }
                else
                    ErrorOccured("Yükleyeceğiniz dosya tipi xls veya xlsx olmalıdır!");

                ArrangeForm();
            }
        }
        catch(Exception ex)
        {
            Logger.LogErrors(ex.ToString());
            ErrorOccured("Beklenmeyen bir hata oluşmuştur! Lütfen tekrar deneyiniz.");
        }
    }

    protected void ErrorOccured(string error)
    {
        Success1.Visible = false;
        Error1.Visible = true;
        Error1.Desc = error;
    }

    protected void Success(string message)
    {
        Error1.Visible = false;
        Success1.Visible = true;
        Success1.Desc = message;
    }

}
