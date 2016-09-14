using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSUKariyer.COMMON.Helpers.WEB;
using GSUKariyer.BUS;
using System.Data;

namespace GSUKariyer.WEB.UserControls.Cv.Edit
{
    public partial class uCVResult : BaseCvEditUserControl
    {
        #region Properties
        public override int ControlOrder
        {
            get
            {
                return CVs.Forms.ControlOrders.CVResult;
            }
        }
        public Errors CVAddErrors
        {
            get {
                return _cvAddErrors;
            }
        }
        #endregion

        protected Errors _cvAddErrors;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrangeForm();
            }

            _cvAddErrors = new Errors(ltrResult);
        }

        #region ArrangeForm
        protected void ArrangeForm()
        {
            hlClose.NavigateUrl = UrlHelper.PageUrl.Student();
            hlClose.Visible = true;
            imgBtnSend.Visible = false;
        }
        #endregion

        #region ButtonEvents
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            Submit();
        }
        #endregion

        public void Bind(bool isNewCv)
        {
            if(isNewCv)
                ltrResult.Text = "Özgeçmişiniz başarıyla eklendi!";
            else
                ltrResult.Text = "Özgeçmişinizdeki değişiklikler tamamlandı!";
        }

        public struct Errors
        {
            Literal _ltrResult;
            public Errors(Literal ltrResult)
            {
                _ltrResult = ltrResult;
            }

            public void SetResult(int resultCode)
            {
                switch (resultCode)
                {
                    case CVs.AddErrorCodes.HasSameNamedCv:
                        _ltrResult.Text = "Özgeçmişiniz eklenemedi! Aynı isimde birden çok cv'niz bulunamaz.";
                        break;
                }
            }
        }
    }
}