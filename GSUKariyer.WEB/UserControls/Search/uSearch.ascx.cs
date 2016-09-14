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
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using GSUKariyer.WEB.UserControls.Common.HelperControls;
using GSUKariyer.COMMON;

namespace GSUKariyer.WEB.UserControls.Search
{
    public partial class uSearch : BaseUserControl
    {
        #region Const Values
        protected const string lbtnCityCountryCArg = "divCityCountry";
        protected const string lbtnPositionsCArg = "divPosition";
        protected const string lbtnDateCArg = "divDate";
        protected const string lbtnSectorsCArg = "divSectors";
        protected const string lbtnWorkTypeCArg = "divWorkType";
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ArrangeForm();
        }

        #region ArrangeForm & BindForm
        protected void ArrangeForm()
        {
            if (!String.IsNullOrEmpty(Request.Form[BUS.Advertisements.SearchHelper.AdvertisementsPage.ControlId.HfAdvertisementsForm]))
            {
                if (Request.Form[BUS.Advertisements.SearchHelper.AdvertisementsPage.ControlId.HfAdvertisementsForm] ==
                    BUS.Advertisements.SearchHelper.AdvertisementsPage.FromAdvertisementsValue)
                {
                    if (this.Page.PreviousPage != null)
                    {
                        ArrangeForm(lbtnCityCountryCArg);
                        ArrangeForm(lbtnDateCArg);
                        ArrangeForm(lbtnPositionsCArg);
                        ArrangeForm(lbtnSectorsCArg);
                        ArrangeForm(lbtnWorkTypeCArg);

                        string searchCriteria = BUS.Advertisements.SearchHelper.AdvertisementsPage.Get(
                            this.Page.PreviousPage).GetSearchCriteria();
                        BUS.Advertisements.SearchHelper searchHelper = BUS.Advertisements.SearchHelper.CriteriaString.GetSearchHelper(searchCriteria);

                        DataSet dsSearchCriteria = searchHelper.GetRptDataSources();

                        rptSearchKeyword.DataSource = dsSearchCriteria.Tables[0];
                        rptSearchKeyword.DataBind();

                        if (dsSearchCriteria.Tables[0].Rows.Count>0)
                            txtKeyword.Text = dsSearchCriteria.Tables[0].Rows[0][BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString();
                        
                        rptDate.DataSource = dsSearchCriteria.Tables[1];
                        rptDate.DataBind();

                        if (dsSearchCriteria.Tables[1].Rows.Count > 0)
                            rblDateOptions.SelectedValue = dsSearchCriteria.Tables[1].Rows[0][BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString();

                        rptSectors.DataSource = dsSearchCriteria.Tables[2];
                        rptSectors.DataBind();

                        foreach (DataRow dr in dsSearchCriteria.Tables[2].Rows)
                        {
                            lbSectors.Items.FindByValue(dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString()).Selected=true;
                        }

                        rptSelectedCityCountry.DataSource = dsSearchCriteria.Tables[3];
                        rptSelectedCityCountry.DataBind();

                        foreach (DataRow dr in dsSearchCriteria.Tables[3].Rows)
                        {
                            lbCityCountry.Items.FindByValue(dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString()).Selected=true;
                        }

                        rptPositions.DataSource = dsSearchCriteria.Tables[4];
                        rptPositions.DataBind();

                        foreach (DataRow dr in dsSearchCriteria.Tables[4].Rows)
                        {
                            lbPosition.Items.FindByValue(dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString()).Selected=true;
                        }
                        
                        rptWorkTypes.DataSource = dsSearchCriteria.Tables[5];
                        rptWorkTypes.DataBind();

                        foreach (DataRow dr in dsSearchCriteria.Tables[5].Rows)
                        {
                            lbWorkType.Items.FindByValue(dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString()).Selected=true;
                        }

                        rptFirm.DataSource = dsSearchCriteria.Tables[6];
                        rptFirm.DataBind();

                        foreach (DataRow dr in dsSearchCriteria.Tables[6].Rows)
                        {

                            if (BUS.Advertisements.SearchHelper.SearchPage.UserFollowedFirms.Value ==
                                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString())
                                chbMyFirms.Checked = true;
                            else
                                txtFirmName.Text = dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value].ToString();
                                                        
                        }
                    }
                }
            }

            rptDate.Visible = (rptDate.Items.Count > 0);
            rptFirm.Visible = (rptFirm.Items.Count > 0);
            rptPositions.Visible = (rptPositions.Items.Count > 0);
            rptSearchKeyword.Visible = (rptSearchKeyword.Items.Count > 0);
            rptSectors.Visible = (rptSectors.Items.Count > 0);
            rptSelectedCityCountry.Visible = (rptSelectedCityCountry.Items.Count > 0);
            rptWorkTypes.Visible = (rptWorkTypes.Items.Count > 0);

            lbtnCityCountry.CommandArgument = lbtnCityCountryCArg;
            lbtnPositions.CommandArgument = lbtnPositionsCArg;
            lbtnDate.CommandArgument = lbtnDateCArg;
            lbtnSectors.CommandArgument = lbtnSectorsCArg;
            lbtnWorkType.CommandArgument = lbtnWorkTypeCArg;

            imgBtnSearch.PostBackUrl = UrlHelper.PageUrl.Advertisements();

            if (SessionManager.IsLoggedIn)
                chbMyFirms.Enabled = true;
            else
                chbMyFirms.Enabled = false;
            
        }
        protected void ArrangeForm(string commandArgument)
        {
            switch (commandArgument)
            {
                case lbtnCityCountryCArg:
                    if (lbCityCountry.Items.Count == 0)
                    {
                        lbCityCountry.DataSource = SiteParams.CityCountry.Get();
                        lbCityCountry.DataTextField = SiteParams.ColumnNames.Description;
                        lbCityCountry.DataValueField = SiteParams.ColumnNames.Value;
                        lbCityCountry.DataBind();
                    }
                    break;
                case lbtnPositionsCArg:
                    if (lbPosition.Items.Count== 0)
                    {
                        lbPosition.DataSource = SiteParams.GetPositions();
                        lbPosition.DataTextField = SiteParams.ColumnNames.Description;
                        lbPosition.DataValueField = SiteParams.ColumnNames.Value;
                        lbPosition.DataBind();
                    }
                    break;
                case lbtnDateCArg:
                    if (rblDateOptions.Items.Count==0)
                    {
                        rblDateOptions.DataSource = BUS.Advertisements.DateOption.GetAll();
                        rblDateOptions.DataTextField = BUS.Advertisements.DateOption.ColumnNames.Description;
                        rblDateOptions.DataValueField = BUS.Advertisements.DateOption.ColumnNames.Value;
                        rblDateOptions.DataBind();
                    }
                    break;
                case lbtnSectorsCArg:
                    if (lbSectors.Items.Count==0)
                    {
                        lbSectors.DataSource = SiteParams.GetSectors();
                        lbSectors.DataTextField = SiteParams.ColumnNames.Description;
                        lbSectors.DataValueField = SiteParams.ColumnNames.Value;
                        lbSectors.DataBind();
                    }
                    break;
                case lbtnWorkTypeCArg:
                    if (lbWorkType.Items.Count == 0)
                    {
                        lbWorkType.DataSource = SiteParams.GetAdvertisementTypes();
                        lbWorkType.DataTextField = SiteParams.ColumnNames.Description;
                        lbWorkType.DataValueField = SiteParams.ColumnNames.Value;
                        lbWorkType.DataBind();
                    }
                    break;

            }
        }
        #endregion

        #region Button Events
        protected void lbtnSearchCriteria_Click(object sender, EventArgs e)
        {
            divCityCountry.Visible = false;
            divDate.Visible = false;
            divFirm.Visible = false;
            divKeyword.Visible = false;
            divPosition.Visible = false;
            divSectors.Visible = false;
            divWorkType.Visible = false;

            string commandArgument = ((LinkButton)sender).CommandArgument;
            ((HtmlControl)this.FindControl(commandArgument)).Visible = true;
            ArrangeForm(commandArgument);

        }
        #endregion

        #region ListBox & Other Events
        protected void lbCityCountry_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedItems = GetListBoxItems(lbCityCountry,lbCityCountry.ID);
            BindUItemRepeater(rptSelectedCityCountry, dtSelectedItems);
        }
        protected void lbSectors_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedItems = GetListBoxItems(lbSectors,lbSectors.ID);
            BindUItemRepeater(rptSectors, dtSelectedItems);
        }
        protected void lbPosition_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedItems = GetListBoxItems(lbPosition, lbPosition.ID);
            BindUItemRepeater(rptPositions, dtSelectedItems);
        }
        protected void lbWorkType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedItems = GetListBoxItems(lbWorkType, lbWorkType.ID);
            BindUItemRepeater(rptWorkTypes, dtSelectedItems);
        }
        protected void rblDateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedValue = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();

            DataRow dr = dtSelectedValue.NewRow();
            dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Definition] = 
                BUS.Advertisements.DateOption.Find(rblDateOptions.SelectedValue).Description;
            dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value] = 
                rblDateOptions.SelectedValue;
            dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.ParentControlId] = 
                rblDateOptions.ID;

            dtSelectedValue.Rows.Add(dr);
            BindUItemRepeater(rptDate,dtSelectedValue);
        }
        protected void ibtnAddKeywordCriteria_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtKeyword.Text.Trim()))
            {
                DataTable dtSelectedValue = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();

                DataRow dr = dtSelectedValue.NewRow();
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Definition] = txtKeyword.Text;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value] = txtKeyword.Text;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.ParentControlId] = txtKeyword.ID;

                dtSelectedValue.Rows.Add(dr);
                BindUItemRepeater(rptSearchKeyword, dtSelectedValue);
            }
        }
        protected void ibtnAddFirmNameCriteria_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFirmName.Text.Trim()))
            {
                DataTable dtSelectedValue = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();

                DataRow dr = dtSelectedValue.NewRow();
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Definition] = txtFirmName.Text;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value] = txtFirmName.Text;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.ParentControlId] = txtFirmName.ID;

                dtSelectedValue.Rows.Add(dr);
                BindUItemRepeater(rptFirm, dtSelectedValue);

                chbMyFirms.Checked = false;
            }
        }
        protected void chbMyFirms_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtSelectedValue = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();

            if (chbMyFirms.Checked)
            {
                DataRow dr = dtSelectedValue.NewRow();
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Definition] = 
                    BUS.Advertisements.SearchHelper.SearchPage.UserFollowedFirms.Description;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value] =
                    BUS.Advertisements.SearchHelper.SearchPage.UserFollowedFirms.Value;
                dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.ParentControlId] = chbMyFirms.ID;

                dtSelectedValue.Rows.Add(dr);
            }

            BindUItemRepeater(rptFirm, dtSelectedValue);
        }
        protected void lbtnOpenSearchCriteria_Click(object sender, EventArgs e)
        {
            divSearchArea.Visible = true;

        }

        protected DataTable GetListBoxItems(ListBox listBox,string parentControlId)
        {
            DataTable dt = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();

            int selectedItemCount=0;
            foreach (ListItem listItem in listBox.Items)
            {
                if (listItem.Selected)
                {
                    if (selectedItemCount == BUS.Advertisements.SearchHelper.SearchPage.MaxSelectedItemCount) 
                    {
                        listItem.Selected = false;
                        continue;
                    }

                    DataRow dr = dt.NewRow();

                    dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Definition] = listItem.Text;
                    dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.Value] = listItem.Value;
                    dr[BUS.Advertisements.SearchHelper.SearchPage.ListColumnNames.ParentControlId] = parentControlId;

                    dt.Rows.Add(dr);
                    selectedItemCount++;
                }
            }

            return dt;
        }
        #endregion

        #region uItem Functions
        protected void UItem1_ItemOnRemove(BaseUserControl sender,string value, string parentControlId)
        {
            object parentControl = this.FindControl(parentControlId);
            DataTable dtSelectedItems=null;

            if (parentControl is ListBox)
            {
                ListBox listBox = (ListBox)this.FindControl(parentControlId);

                foreach (ListItem listItem in listBox.Items)
                {
                    if (listItem.Value == value)
                        listItem.Selected = false;
                }

                dtSelectedItems = GetListBoxItems(listBox, listBox.ID);
            }
            else if (parentControl is RadioButtonList)
            {
                (this.FindControl(parentControlId) as RadioButtonList).SelectedIndex = -1;
                dtSelectedItems = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();
            }
            else if (parentControl is TextBox)
            {
                (this.FindControl(parentControlId) as TextBox).Text = String.Empty;
                dtSelectedItems = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable();
            }
            else if (parentControl is CheckBox)
            {
                (this.FindControl(parentControlId) as CheckBox).Checked = false;
                dtSelectedItems = BUS.Advertisements.SearchHelper.SearchPage.CreateSelectedValueTable(); 
            }

            Repeater repeater = (Repeater)sender.Parent.Parent;
            BindUItemRepeater(repeater,dtSelectedItems);
        }
        protected void BindUItemRepeater(Repeater repeater,DataTable dt)
        {
            repeater.DataSource = dt;
            repeater.DataBind();

            if (repeater.Items.Count < 1)
                repeater.Visible = false;
            else
                repeater.Visible = true;
        }
        #endregion

    }
}