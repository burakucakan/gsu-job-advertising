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
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;

namespace GSUKariyer.WEB.UserControls.Signup
{
    public partial class uSignup : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            succSave.Visible = false;
            succSaveEmailNotSend.Visible = false;
            errGsuStudent.Visible = false;
            errHasUser.Visible = false;
            errSave.Visible = false;
            pnlForm.Visible = true;
            
            if (!IsPostBack)
            {
                Fill();
                SetLocationSettings();
                if (this.SessionManager.IsLoggedIn) {
                    DataTable dtUser = BUS.Users.Generated.Get(this.SessionManager.UserId.Value);
                    if (dtUser.Rows.Count > 0) {
                        txtName.Text = dtUser.Rows[0]["Name"].ToString();
                        txtSurname.Text = dtUser.Rows[0]["Surname"].ToString();
                        txtNationalId.Text = dtUser.Rows[0]["NationalId"].ToString();
                        txtEmail.Text = dtUser.Rows[0]["Email"].ToString();
                        txtStudentNumber.Text = dtUser.Rows[0]["StudentNumber"].ToString();

                        txtBirthdate.Text = (dtUser.Rows[0][BUS.Users.ColumnNames.Birthdate] == DBNull.Value) ? "" : dtUser.Rows[0][BUS.Users.ColumnNames.Birthdate].ToDateTime().ToLongDateString();
                        uCountries1.SelectedValue = dtUser.Rows[0][BUS.Users.ColumnNames.Country].ToString();
                        uCities1.SelectedValue = dtUser.Rows[0][BUS.Users.ColumnNames.City].ToString();
                        txtAddress.Text = dtUser.Rows[0][BUS.Users.ColumnNames.Address].ToString();

                        rdMale.Checked = dtUser.Rows[0]["Gender"].ToInt() == (int)BUS.Users.Gender.Male;
                        rdFemale.Checked = !rdMale.Checked;

                        txtStudentNumber.Enabled = false;
                        hdPassword.Value = dtUser.Rows[0]["Password"].ToString();
                        reqPass.Visible = false;
                        reqPass2.Visible = false;

                        pnlLoginOff.Visible = false;

                        imgBtnSend.ImageUrl = "~/Images/Button/Save.jpg";
                    }
                }
            }
        }

        protected void Fill()
        {
            uCountries1.SelectedValue = ((int)BUS.SiteParams.TurkeyCountryCode).ToString();
            DateTime MaxDate = new DateTime(DateTime.Now.AddYears(-18).Year, 12, 31);
            ceBirthDate.MaximumDate = MaxDate;
        }
        
        protected void SetLocationSettings()
        {
            uCities1.FreeItemValue = SiteParams.CityCountry.otherCityValue;
            uCities1.ParentControl = uCountries1;
        }

        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string Name = Util.r(txtName.Text);
                string Surname = Util.r(txtSurname.Text);
                string NationalId = Util.r(txtNationalId.Text.Trim());
                string Email = Util.r(txtEmail.Text.Trim());
                string Password = Encryption.Encrypt(Util.r(txtPassword.Text.Trim()));
                string StudentNumber = Util.r(txtStudentNumber.Text.Trim());

                DateTime? BirthDate;
                try
                { BirthDate = txtBirthdate.Text.ToDateTime(); }
                catch (Exception)
                { BirthDate = ceBirthDate.MaximumDate.Value; }

                int Country = int.Parse(uCountries1.SelectedValue);
                int City = int.Parse(uCities1.SelectedValue);
                string Address = Util.r(txtAddress.Text);

                int Gender = (rdMale.Checked) ? (int)BUS.Users.Gender.Male : (int)BUS.Users.Gender.Female;

                if (!this.SessionManager.IsLoggedIn)
                {

                    bool IsGsuStudent = false;
                    bool HasUser = false;
                    bool IsSave = false;
                    bool IsSendActivateMail = false;

                    //TODO : ** Excel'den ÖĞrenci No'ya karşı gelen Mail Adresi
                    string ActivateEmail = GetActivateEmail(StudentNumber);
                    IsGsuStudent = (ActivateEmail != "");

                    if (!IsGsuStudent)
                        errGsuStudent.Visible = true;
                    else
                    {

                        HasUser = BUS.Users.HasUser(StudentNumber);

                        if (HasUser)
                            errHasUser.Visible = true;
                        else
                        {

                            string ActivationCode = AppUtil.genActivatonCode();
                            try
                            {
                                IsSave = (Users.Generated.Add(Name, Surname, NationalId, BirthDate, StudentNumber, Gender, Email, null, Address, Country, City, null, Password, ActivationCode, false, false, DateTime.Now, DateTime.Now, DateTime.Now)) > 0;
                            }
                            catch (Exception)
                            {

                                IsSave = false;
                            }

                            if (IsSave)
                            {
                                Mail objMail = new Mail();
                                IsSendActivateMail = objMail.SendActivate(ActivateEmail, ActivationCode);

                                if (IsSendActivateMail)
                                {
                                    succSave.Visible = true;
                                    hlActivateEmail.Text = ActivateEmail;
                                    hlActivateEmail.NavigateUrl += ActivateEmail;
                                }
                                else
                                {
                                    succSaveEmailNotSend.Visible = true;
                                    hlActivateEmail2.Text = ActivateEmail;
                                    hlActivateEmail2.NavigateUrl += ActivateEmail;
                                }
                                pnlForm.Visible = false;
                            }
                            else
                                errSave.Visible = true;
                        }
                    }
                }
                else
                {
                    if (txtPassword.Text.Trim() == String.Empty) Password = hdPassword.Value;
                    succUpdate.Visible = Users.Update(this.SessionManager.UserId.Value, Name, Surname, StudentNumber, Gender, BirthDate.Value, Country, City, Address, Email, Password);
                    errSave.Visible = !succUpdate.Visible;
                    pnlForm.Visible = false;
                }
            }
        }

        private string GetActivateEmail(string StudentNumber) {
            string Email;
            DataTable dtUserEmail = UserEmails.GetUser(StudentNumber);
            if (dtUserEmail.Rows.Count < 1) return "";

            Email = dtUserEmail.Rows[0][UserEmails.ColumnNames.Email].ToString();
            return Email.Trim();
        }
    }
}