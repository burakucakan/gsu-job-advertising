using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GSUKariyer.COMMON.Helpers.WEB;
using System.Text;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB
{
    public partial class Main : BaseCompressedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            #region GSClubs
            /*
            string insertFormat = "Insert into SiteParams(ParamName,ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}','{3}',{4})";
            string positons = TextBox1.Text.Trim();
            string[] atoms = positons.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            int i = 0;
            string paramName = String.Empty;
            
            foreach (string position in atoms)
            {
                string desc;
                string value;

                if (position[0] == '1')
                {
                    paramName = SiteParams.ParamName.AkademicClubs;
                    continue;
                }
                else if (position[0] == '2')
                {
                    paramName = SiteParams.ParamName.SporClubs;
                    continue;
                }
                else if (position[0] == '3')
                {
                    paramName = SiteParams.ParamName.CulturalClubs;
                    continue;
                }

                if (position[0] == '*')
                {
                    desc = position.Substring(1).Trim();
                    value =i.ToString();

                    i++;
                }
                else
                {
                    continue;
                }


                builder.AppendLine(String.Format(insertFormat, paramName, SiteParams.ParamGroup.GSClubs, desc, value, (i * 10).ToString()));
            }

            TextBox2.Text = builder.ToString();
             */
            #endregion

            #region Positions & Sectors
            /*
            string insertFormat = "Insert into SiteParams(ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}',{3})";
            string positons = TextBox1.Text.Trim();
            string[] atoms = positons.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            int i = 0;
            string prevPositionCode = String.Empty;
            int childIndex = 1;
            foreach (string position in atoms)
            {                
                string desc;
                string positionCode;

                if (position[0] == ' ')
                {
                    desc = String.Concat("- ", position.Substring(3).Trim());
                    positionCode = String.Concat(prevPositionCode.Substring(0, 3), childIndex.ToString().PadLeft(2, '0'));
                    childIndex++;
                }
                else
                {
                    desc = position.Trim();
                    positionCode=String.Concat(i.ToString().PadLeft(3,'0'),"");
                    prevPositionCode = positionCode;
                    childIndex = 1;
                    i++;
                }

                builder.AppendLine(String.Format(insertFormat, "Sectors", desc,positionCode , (i * 10).ToString()));
            }

            TextBox2.Text = builder.ToString();
            */
            #endregion

            #region Countries
            /*
            string insertFormat = "Insert into SiteParams(ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}',{3})";
            string countries = TextBox1.Text.Trim();
            string[] atoms = countries.Split(new string[] { "<option value=\"" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string country in atoms)
            {
                string value;
                string desc;

                value = country.Substring(0, country.IndexOf("\""));
                desc = country.Substring(country.IndexOf(">") + 1);

                builder.AppendLine(String.Format(insertFormat, "Countries", desc, value, (i * 10).ToString()));
                i++;
            }

            TextBox2.Text = builder.ToString();
            */
            #endregion

            #region Languages
            /*
            string insertFormat = "Insert into SiteParams(ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}',{3})";
            string countries = TextBox1.Text.Trim();
            string[] atoms = countries.Split(new string[] { "<option value=\"" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string country in atoms)
            {
                string value;
                string desc;

                value = int.Parse(country.Substring(0, country.IndexOf("\"")).Replace("</option>", String.Empty)).ToString();
                desc = country.Substring(country.IndexOf(">") + 1).Replace("</option>", String.Empty);

                builder.AppendLine(String.Format(insertFormat, "Languages", desc, value, (i * 10).ToString()));
                i++;
            }

            TextBox2.Text = builder.ToString();
           */
            #endregion

            #region CertificateCategory
            //string insertFormat = "Insert into SiteParams(ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}',{3})";
            //string countries = TextBox1.Text.Trim();
            //string[] atoms = countries.Split(new string[] { "<option value=\"" }, StringSplitOptions.RemoveEmptyEntries);

            //StringBuilder builder = new StringBuilder();
            //int i = 0;
            //foreach (string country in atoms)
            //{
            //    string value;
            //    string desc;

            //    value = int.Parse(country.Substring(0, country.IndexOf("\"")).Replace("</option>", String.Empty)).ToString();
            //    desc = country.Substring(country.IndexOf(">") + 1).Replace("</option>", String.Empty);

            //    builder.AppendLine(String.Format(insertFormat, TextBox3.Text, desc, value, (i * 10).ToString()));
            //    i++;
            //}

            //TextBox2.Text = builder.ToString();
            #endregion

            #region Univ Institute & Departments
            /*
            string insertFormat = "Insert into SiteParams(ParamGroup,ParamName,Description,[Value],[Order])Values('{0}','{1}','{2}','{3}',{4})";

            string univDepartments = TextBox1.Text.Trim();
            string[] atoms = univDepartments.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();            
            int valueInt = 0;
            int instituteId=0;
            for (int i = 0; i < atoms.Length;i=i+3 )
            {
                string position;

                string[] innerAtoms;
                string desc;
                string paramName;
                string paramGroup;
                string value;
                string language;
                bool isInstitute=false;

                value = (valueInt++).ToString();

                //i
                position = atoms[i];
                if (position[0] == '-')
                {
                    isInstitute=true;
                    position=position.Substring(1);
                    paramName = String.Empty;
                    instituteId= int.Parse(value);
                    paramGroup = "UniversityInstitude";
                }
                else
                {
                    isInstitute = false;
                    paramGroup = "UniversityDepartments";
                    paramName = instituteId.ToString();
                }


                innerAtoms = position.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                desc = String.Concat(innerAtoms[1]);
                language = innerAtoms[0];

                if (language != "tr")
                    paramGroup = String.Concat(paramGroup,"_",language);

                builder.AppendLine(String.Format(insertFormat, paramGroup,paramName.Trim(), desc.Trim(),value.Trim(),(i*10).ToString()));

                //i + 1
                position = atoms[i+1];
                if (position[0] == '-')
                {
                    isInstitute = true;
                    position = position.Substring(1);
                    paramName = String.Empty;
                    instituteId = int.Parse(value);
                    paramGroup = "UniversityInstitude";
                }
                else
                {
                    isInstitute = false;
                    paramGroup = "UniversityDepartments";
                    paramName = instituteId.ToString();
                }


                innerAtoms = position.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                desc = String.Concat(innerAtoms[1]);
                language = innerAtoms[0];
                if (language != "tr")
                    paramGroup = String.Concat(paramGroup, "_", language);

                builder.AppendLine(String.Format(insertFormat, paramGroup, paramName.Trim(), desc.Trim(), value.Trim(), ((i+1) * 10).ToString()));

                //i + 2
                position = atoms[i + 2];
                if (position[0] == '-')
                {
                    isInstitute = true;
                    position = position.Substring(1);
                    paramName = String.Empty;
                    instituteId = int.Parse(value);
                    paramGroup = "UniversityInstitude";
                }
                else
                {
                    isInstitute = false;
                    paramGroup = "UniversityDepartments";
                    paramName = instituteId.ToString();
                }


                innerAtoms = position.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                desc = String.Concat(innerAtoms[1]);
                language = innerAtoms[0];
                if (language != "tr")
                    paramGroup = String.Concat(paramGroup, "_", language);

                builder.AppendLine(String.Format(insertFormat, paramGroup, paramName.Trim(), desc.Trim(), value.Trim(), ((i+2) * 10).ToString()));

                
            }

            TextBox2.Text = builder.ToString();
            */
            #endregion


            #region Languages-MultiLanguage
           
            string insertFormat = "Insert into SiteParams(ParamGroup,Description,[Value],[Order])Values('{0}','{1}','{2}',{3})";
            string countries = TextBox1.Text.Trim();
            string[] atoms = countries.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string language in atoms)
            {
               string[] atomsLang = language.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                builder.AppendLine(String.Format(insertFormat, "Languages", atomsLang[0], i.ToString(), (i * 10).ToString()));

                builder.AppendLine(String.Format(insertFormat, "Languages_eng", atomsLang[1], i.ToString(), (i * 10).ToString()));

                builder.AppendLine(String.Format(insertFormat, "Languages_fre", atomsLang[2], i.ToString(), (i * 10).ToString()));
                
                i++;
            }

            TextBox2.Text = builder.ToString();
          
            #endregion
        }

    }
}
