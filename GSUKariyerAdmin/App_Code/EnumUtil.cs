using System;
using System.Collections.Generic;
using System.Text;

public class EnumUtil
{
    public enum Config
    {
        EMailServer,
        ToAdmin,
        MailServer,
        MailDisplayName,
        MailUser,
        MailPass,
        MailMain,

        ListPageSize,
        UploadedFilesFolder,
        TempUploadFolder,
        UserImportsUploadFolder,
        MaxKB,
        MailTempletePath,
        ApplicationUrl,

        WebPath,
        ImgPathRoot,
        ImgPathRootCarrerPlaning,
        ImgPathCompany,
        ImgPathUsers,
        ImgPathBanner

    }

    public enum Sess
    {
        IsLogin,
        AdminID,
        Email,
        FirstName,
        Surname,
        Permissions,
        Photo
    }

    public enum CacheTypes
    {
        //Errors = 1,
    }

    public enum CachePeriods
    {
        //Errors = 100,
    }

    public enum Cookies
    {
        UserID = 1
    }
}
