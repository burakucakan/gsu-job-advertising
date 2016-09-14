using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON.Exceptions
{
    public class MyException:Exception
    {
        private string className = null;
        private string functionName =null;
        private string pageName = null;
        private string userIp = null;
        private string[] parameterValues;
        
        #region Constructers
        public MyException(): base()
        {
        }

        public MyException(Exception ex, params string[] parameterValues)
            : this(ex,null,null,parameterValues)
        { 
        }
        public MyException(Exception ex,string className, string functionName, params string[] parameterValues)
            : base("Exception occured. Look at inner exception",ex)
        {
            this.className=className;
            this.functionName = functionName;
            this.parameterValues = parameterValues;
        }

        public MyException(string exceptionMessage, params string[] parameterValues)
            :this(exceptionMessage,null,null,parameterValues)
        { 
        }
        public MyException(string exceptionMessage, string className, string functionName, params string[] parameterValues)
            : base(exceptionMessage)
        {
            this.className = className;
            this.functionName = functionName;
            this.parameterValues = parameterValues;
        }

        public MyException(Exception ex, string pageName, string userIp)
            : base("Exception occured. Look at inner exception", ex)
        {
            this.pageName = pageName;
            this.userIp = userIp;
        }
        #endregion

        public override string Message
        {
            get
            {
                return base.Message;


                //StringBuilder errorBuilder = new StringBuilder();                

                ////Generating Exception Description
                //errorBuilder.AppendLine("/**********MyException**********/");

                //if (!String.IsNullOrEmpty(pageName))
                //{
                //    errorBuilder.AppendLine("Page Name: ");
                //    errorBuilder.Append(pageName);
                //}

                //if (!String.IsNullOrEmpty(userIp))
                //{
                //    errorBuilder.AppendLine("User Ip: ");
                //    errorBuilder.Append(userIp);
                //}

                //if (!String.IsNullOrEmpty(functionName))
                //{
                //    errorBuilder.AppendLine("Function Name: ");
                //    errorBuilder.Append(functionName);
                //}

                //errorBuilder.AppendLine("Exception Message:");
                //errorBuilder.AppendLine(base.ToString());

                ////Adding Parameter Values
                //if (parameterValues.Length > 0)
                //{
                //    errorBuilder.AppendLine("Function Parameters Delimeted By Comma: ");

                //    string parameters=String.Empty;
                //    for (int i = 0; i < parameterValues.Length; i++)
                //        parameters = String.Concat(parameters, parameterValues[i],",");

                //    errorBuilder.AppendLine(parameters.Substring(0, parameters.Length - 1));
                //}

                ////Adding Inner Exception Message
                //errorBuilder.AppendLine("Inner Exceptions");

                //Exception tempException = this;
                //for (;;)
                //{
                //    if (tempException.InnerException == null)
                //        break;
                //    else
                //        tempException = tempException.InnerException;

                //    errorBuilder.AppendLine(String.Format("Inner Exception ::{0}:::", tempException.Message));
                //}

                //errorBuilder.AppendLine("/*********MyException End**********/");
                //return errorBuilder.ToString();
            }
        }
    }
}
