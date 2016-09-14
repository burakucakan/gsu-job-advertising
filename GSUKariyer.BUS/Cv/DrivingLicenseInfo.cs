using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GSUKariyer.DAL;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class DrivingLicenseInfo : CVCourseInfo
        {
            public static int Update(int cvId,bool hasDrivingLicense,DateTime modifyDate)
            {
                return CVsProvider.UpdateCVDrivingInfo(null,cvId,hasDrivingLicense,modifyDate);
            }
            public static DataTable GetData()
            {
                DataTable dt = SiteParams.CreateTable();
                DataRow dr;

                dr = dt.NewRow();
                dr[SiteParams.ColumnNames.Description] = "Var";
                dr[SiteParams.ColumnNames.Value] = true.ToString();
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[SiteParams.ColumnNames.Description] = "Yok";
                dr[SiteParams.ColumnNames.Value] = false.ToString();
                dt.Rows.Add(dr);

                return dt;
            }
        } 
    }
}
