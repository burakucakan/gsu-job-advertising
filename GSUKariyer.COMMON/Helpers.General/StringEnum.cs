using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON
{
    public class StringEnum
    {
        public struct ColumnNames
        {
            public const string Description = "Description";
            public const string Value = "Value";
        }

        protected string _value;
        protected string _description;

        public StringEnum(string description,string value)
        {
            Check.Require(description != null, "description can not be null.");
            Check.Require(value != null, "value can not be null.");
            this._description = description;
            this._value = value;
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
