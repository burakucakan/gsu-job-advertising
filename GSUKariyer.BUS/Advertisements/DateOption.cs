using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{
    public partial class Advertisements
    {
        public class DateOption : StringEnum
        {
            protected static List<DateOption> enumList;

            public static readonly DateOption Today;
            public static readonly DateOption Last3Days;
            public static readonly DateOption Last7Days;
            public static readonly DateOption Last15Days;
            public static readonly DateOption LastMonth;
            public static readonly DateOption All;

            #region Constructers
            static DateOption()
            {
                enumList = new List<DateOption>();
                Today = new DateOption("Bugünün ilanları", "Today");
                enumList.Add(Today);
                Last3Days = new DateOption("Son 3 gün", "Last3Days");
                enumList.Add(Last3Days);
                Last7Days = new DateOption("Son 7 gün", "Last7Days");
                enumList.Add(Last7Days);
                Last15Days = new DateOption("Son 15 gün", "Last15Days");
                enumList.Add(Last15Days);
                LastMonth = new DateOption("Son 1 ay", "LastMonth");
                enumList.Add(LastMonth);
                All = new DateOption("Hepsi", "All");
                enumList.Add(All);
            }
            public DateOption(string description, string value): base(description,value)
            {
                _value = value;
            }
            #endregion

            #region Public Functions
            public static DateOption Find(string value)
            {
                DateOption foundObj = null;

                foundObj = enumList.Find(delegate(DateOption dateOption)
                    {
                        return dateOption.Value == value;
                    });

                return foundObj;
            }
            public static DataTable GetAll()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(SiteParams.ColumnNames.Description);
                dt.Columns.Add(SiteParams.ColumnNames.Value);

                foreach (DateOption dateOption in enumList)
                {
                    DataRow dr = dt.NewRow();

                    dr[SiteParams.ColumnNames.Description] = dateOption.Description;
                    dr[SiteParams.ColumnNames.Value] = dateOption.Value;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            #endregion
        }
    }
}
