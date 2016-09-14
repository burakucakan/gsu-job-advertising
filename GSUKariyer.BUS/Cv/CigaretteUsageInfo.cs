using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class CigaretteUsageInfo 
        {
            public static int Update(SqlTransaction tran,int cvId,int cigaretteUsageType,DateTime modifyDate)
            {
                return CVsProvider.UpdateCigaretteUsageInfo(tran,cvId,cigaretteUsageType,modifyDate);
            }
            public static int Update(int cvId, int cigaretteUsageType, DateTime modifyDate)
            {
                return CVsProvider.UpdateCigaretteUsageInfo(null, cvId, cigaretteUsageType, modifyDate);
            }
        } 
    }
}
