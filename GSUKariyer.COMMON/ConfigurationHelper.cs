using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON
{
    public partial class ConfigurationHelper
    {
        public struct AppSettingKeys
        {
            public const string ConnStrName = "ConnStrName";
            public const string LogName = "LogName";
            public const string AppName = "AppName";
            public const string UnloggedErrorsFilePath = "UnloggedErrorsFilePath";

            public const string WebPath = "WebPath";

            public const string ImgPathRoot = "ImgPathRoot";
            public const string ImgPathRootCarrerPlaning = "ImgPathRootCarrerPlaning";
            public const string ImgPathCompany = "ImgPathCompany";
            public const string ImgPathUsers = "ImgPathUsers";
            public const string ImgPathBanner = "ImgPathBanner";

            public const string ImgUploadMaxKB = "ImgUploadMaxKB";

            public const string ToAdmin = "ToAdmin";
        }

        public struct AppSettingKeysAdmin
        {
            public const string MaxKB = "MaxKB";

            public const string PhysicalLivePath = "PhysicalLivePath";
            public const string PhysicalImgPathRoot = "PhysicalImgPathRoot";
            public const string ImgFolderCarrerPlaning = "ImgFolderCarrerPlaning";

            public const string ImgPathRoot = "ImgPathRoot";
            public const string ImgPathRootCarrerPlaning = "ImgPathRootCarrerPlaning";
            public const string ImgPathCompany = "ImgPathCompany";
            public const string ImgPathUsers = "ImgPathUsers";
            public const string ImgPathBanner = "ImgPathBanner";
        }
    }
}
