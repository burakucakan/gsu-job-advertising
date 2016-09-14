using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.COMMON;
using GSUKariyer.BUS;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uPositions : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.InterestedJobPositions;
            }
        }
        public int? InterestedAdversementType
        {
            get { return uAdvertisementTypes1.SelectedValue.ToNullableInt(); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
            }
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            lbPositions.DataSource = SiteParams.GetPositions();
            lbPositions.DataTextField = SiteParams.ColumnNames.Description;
            lbPositions.DataValueField = SiteParams.ColumnNames.Value;
            lbPositions.DataBind();
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsNewCV)
                CVs.InterestedJobPositions.Update(CVId.Value,InterestedAdversementType.Value,GetData(),
                    DateTime.Now);

            Submit();
        }

        protected void lbtnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lbMyPositions.SelectedIndex != -1)
            {
                DataTable dt=CVs.InterestedJobPositions.CreateTable();
                dt.Columns.Add(SiteParams.ColumnNames.Description);

                foreach (ListItem listItem in lbMyPositions.Items)
                {
                    if (!listItem.Selected)
                    {
                        DataRow dr=dt.NewRow();

                        dr[SiteParams.ColumnNames.Description] = listItem.Text;
                        dr[CVs.InterestedJobPositions.ColumnNames.InterestedJobPositions] = listItem.Value;

                        dt.Rows.Add(dr);
                    }
                }

                Bind(InterestedAdversementType,dt);
            }

            lbMyPositions.SelectedIndex = -1;
        }

        protected void lbtnAddSelected_Click(object sender, EventArgs e)
        {
            if (lbPositions.SelectedIndex != -1)
            {
                foreach(ListItem listItem in lbPositions.Items)
                {
                    if (listItem.Selected && (!lbMyPositions.Items.Contains(listItem)))
                        lbMyPositions.Items.Add(new ListItem(listItem.Text,listItem.Value));
                }
            }

            lbPositions.SelectedIndex = -1;
        }
        #endregion

        public void Bind(int? interestedAdvertisementType,DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                if (!dt.Columns.Contains(SiteParams.ColumnNames.Description))
                {
                    dt.Columns.Add(SiteParams.ColumnNames.Description);

                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[SiteParams.ColumnNames.Description] = SiteParams.GetPositionDescription(
                            dr[CVs.InterestedJobPositions.ColumnNames.InterestedJobPositions].ToString());
                    }
                }

                lbMyPositions.DataSource=dt;
                lbMyPositions.DataTextField = SiteParams.ColumnNames.Description;
                lbMyPositions.DataValueField = CVs.InterestedJobPositions.ColumnNames.InterestedJobPositions;
                lbMyPositions.DataBind();

                uAdvertisementTypes1.SelectedValue = interestedAdvertisementType.ToString();
            }
            else
                ThrowNoDataException("Bind");
        }

        #region Others
        public DataTable GetData()
        {
            DataTable dt = CVs.InterestedJobPositions.CreateTable();

            int order=0;
            foreach (ListItem listItem in lbMyPositions.Items)
            {
                DataRow dr = dt.NewRow();

                dr[CVs.InterestedJobPositions.ColumnNames.InterestedJobPositions] = listItem.Value;
                dr[CVs.InterestedJobPositions.ColumnNames.Order] = order;

                dt.Rows.Add(dr);
            }

            return dt;
        }
        #endregion
    }
}