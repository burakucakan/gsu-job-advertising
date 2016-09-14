using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GSUKariyer.BUS
{
    public partial class CVs
    {
        public class Languages
        {
            public class Options
            {
                #region Const Values
                public const string Turkish = "0";
                public const string English = "1";
                public const string French = "2";

                protected const string TurkishDesc = "Türkçe";
                protected const string EnglishDesc = "İngilizce";
                protected const string FrenchDesc = "Fransızca";
                #endregion

                #region Columns
                public struct ColumnNames
                {
                    public const string Desc = "Desc";
                    public const string Value = "Value";
                }
                #endregion

                public static DataTable Get()
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add(ColumnNames.Desc);
                    dt.Columns.Add(ColumnNames.Value);

                    DataRow dr = dt.NewRow();
                    dr[ColumnNames.Desc] = TurkishDesc;
                    dr[ColumnNames.Value] = Turkish;
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[ColumnNames.Desc] = EnglishDesc;
                    dr[ColumnNames.Value] = English;
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr[ColumnNames.Desc] = FrenchDesc;
                    dr[ColumnNames.Value] = French;
                    dt.Rows.Add(dr);

                    return dt;
                }

                public static string Get(string language)
                {
                    switch (language)
                    {
                        case Turkish:
                            return TurkishDesc;
                        case English:
                            return EnglishDesc;
                        case French:
                            return FrenchDesc;
                    }

                    return String.Empty;
                }

                public static string ArrangeCvLanguageDBValue(string language)
                {
                    if (language == "0")
                        return "tr";
                    else if (language == "1")
                        return "eng";
                    else if (language == "2")
                        return "fre";

                    return String.Empty;
                }
            }

        }
    }
}
