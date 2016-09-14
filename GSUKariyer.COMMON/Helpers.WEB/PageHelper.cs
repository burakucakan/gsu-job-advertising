using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class PageHelper
    {
        public static string GetPageNameWithOutExtention(string pageName)
        {
            pageName = System.IO.Path.GetFileName(pageName);
            int pointIndex = pageName.LastIndexOf('.');

            if (pointIndex != -1)
                pageName = pageName.Substring(0, pointIndex);

            return pageName;
        }

        public static string GetPageName()
        {
            string rawUrl = System.Web.HttpContext.Current.Request.RawUrl;

            if (rawUrl.IndexOf("?") != -1)
            {
                rawUrl = rawUrl.Substring(0, rawUrl.IndexOf("?"));
            }

            return System.IO.Path.GetFileName(rawUrl);
        }
        public static string GetPreviousUri()
        {
            if (((System.Web.HttpContext.Current.Request.UrlReferrer != null)))
            {
                return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
            }

            return "";
        }



        public class UrlParam
        {
            public string Key = "";
            public string Value = "";
            public UrlParam()
            { }
            public UrlParam(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        ///<summary>
        ///Returns URL with params
        ///</summary>
        ///<param name="url"></param>
        ///<param name="paramList">Dictionary Key is parmaname and Value is paramvalue</param>
        ///<returns></returns>

        public static string GetURLWithParams(string url, Dictionary<string, string> paramList)
        {
            return GetURLWithParams(url, false, paramList);
        }

        public static string GetURLWithParams(string url, bool getAbsolutePath, Dictionary<string, string> paramList)
        {
            StringBuilder urlBuild = new StringBuilder(((getAbsolutePath) ? "~/" : ""));
            urlBuild.Append(url);

            if (paramList != null && paramList.Count > 0)
            {
                urlBuild = urlBuild.Append("?");
                foreach (string key in paramList.Keys)
                {
                    urlBuild = urlBuild.Append(key.ToString() + "=" + paramList[key] + "&");
                }

                url = urlBuild.ToString();
                return url.TrimEnd('&');
            }
            return urlBuild.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="getAbsolutePath">add to the begining of url ~/</param>
        /// <param name="paramList">Query param list</param>
        /// <returns></returns>
        public static string GetURLWithParams(string url, bool getAbsolutePath, params UrlParam[] paramList)
        {
            StringBuilder urlBuild = new StringBuilder(((getAbsolutePath) ? "~/" : ""));
            urlBuild.Append(url);
            if (paramList != null && paramList.Length > 0)
            {
                urlBuild.Append("?");
                for (int i = 0; i < paramList.Length; i++)
                {
                    urlBuild = urlBuild.Append(paramList[i].Key).Append("=").Append(paramList[i].Value).Append("&");
                }
            }
            return urlBuild.ToString().TrimEnd('&');
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="paramList">Query ParamList</param>
        /// <returns></returns>
        public static string GetURLWithParams(string url, params UrlParam[] paramList)
        {
            return GetURLWithParams(url, false, paramList);
        }
    }
}
