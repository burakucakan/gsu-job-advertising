using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSUKariyer.BUS
{
    public partial class Advertisements
    {
        public partial class SearchHelper
        {
            public class AdvertisementsPage
            {
                public const string FromAdvertisementsValue = "FromAdvertisements";
                protected const string AdvertisementsControl = "uAdvertisements1";
                protected const string ContentPlaceHolderId = "ContentPlaceHolder1";

                public struct Mode
                {
                    public const string Date = "Date";
                    public const string Sectors="Sectors";
                    public const string CityCountry="CityCountry";
                    public const string MostSuitable = "MostSuitable";
                    public const string WorkType = "WorkType";
                    public const string Fast = "Fast";
                }

                #region ControlId
                public struct ControlId
                {
                    public const string HfAdvertisementsForm = "hfAdvertisementsForm";
                    public const string HfSearchCriteria = "hfSearchCriteria";
                }
                #endregion

                UserControl _control;

                #region Constructers
                public AdvertisementsPage(UserControl control)
                {
                    _control = control;
                }
                #endregion

                #region Public Functions
                public string GetSearchCriteria()
                {
                    return ((HiddenField)_control.FindControl(ControlId.HfSearchCriteria)).Value;
                }
                public static string GetSearchCriteria(Page value)
                {
                    return ((HiddenField)((UserControl)value.Master.FindControl(
                        ContentPlaceHolderId).FindControl(AdvertisementsControl)).FindControl(
                        ControlId.HfSearchCriteria)).Value;
                }
                public static AdvertisementsPage Get(Page value)
                {
                    return new AdvertisementsPage((UserControl)value.Master.FindControl(
                        ContentPlaceHolderId).FindControl(AdvertisementsControl));
                }
                #endregion
            }
        }
    }
}
