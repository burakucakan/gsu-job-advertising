using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS.Helpers
{
    public class DateDefinitionHelper
    {
        #region Enums
        public enum ControlMode
        {
            OnlyDate=0,
            Mixed=1
        }
        #endregion

        protected DateTime _date;
        protected ControlMode _mode;

        #region Properties
        public DateTime Date
        {
            get { return _date; }
        }
        public ControlMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public string Definition
        {
            get { return ArrangeDescription(); }
        }
        #endregion

        #region Contructers
        public DateDefinitionHelper(DateTime date)
        {
            _date = date;
            _mode = ControlMode.Mixed;
        }
        public DateDefinitionHelper(DateTime date,ControlMode mode)
        {
            _date = date;
            _mode = mode;
        }
        #endregion

        protected string ArrangeDescription()
        {
            string retval = String.Empty;

            switch (_mode)
            {
                case ControlMode.Mixed :
                    if (_date.Date == DateTime.Now.Date)
                        retval = "Bugün";
                    else if (_date.Date.AddDays(1) == DateTime.Now.Date)
                        retval = "Dün";
                    else
                        retval = _date.ToShortDateString();
                    break;
                case ControlMode.OnlyDate:
                    retval = _date.ToShortDateString();
                    break;
            }
       
            return retval;
        }
    }
}
