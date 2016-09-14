using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GSUKariyer.COMMON
{
    public class FileHelper
    {
        public static void CopyFile(string sourceFilePath, string destFilePath)
        {
            if (File.Exists(sourceFilePath))
            {
                File.Copy(sourceFilePath, destFilePath);
            }
        }

        public static void MoveFile(string sourceFilePath, string destFilePath)
        {
            if (File.Exists(sourceFilePath))
            {
                File.Copy(sourceFilePath, destFilePath);
                File.Delete(sourceFilePath);
            }
        }

        public static bool FileDelete(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public static string GetFilePath(string Path)
        {
            return System.Web.HttpContext.Current.Request.MapPath(Path);
        }

        public static bool GetFileParts(string filePath, ref string fileNameWithOutExtention, ref string fileExtention)
        {
            int iPoint = filePath.LastIndexOf(".");
            int iSlash = filePath.LastIndexOf("\\");

            if ((iPoint != -1))
            {
                fileExtention = filePath.Substring(iPoint + 1);
                fileNameWithOutExtention = filePath.Substring(iSlash + 1, iPoint - iSlash - 1);

                return true;
            }

            return false;
        }

        public static string GetFileExtention(string filePath)
        {
            string fileExtention = "";

            int iPoint = filePath.LastIndexOf(".");
            int iSlash = filePath.LastIndexOf("\\");

            if ((iPoint != -1))
            {
                fileExtention = filePath.Substring(iPoint + 1);
            }

            return fileExtention.ToUpper();
        }

        public static bool HasRightFileExtention(string fileExtention, string fileExtentionTemplate)
        {
            fileExtention = fileExtention.ToLower().Replace("ı", "i");

            if ((fileExtentionTemplate.IndexOf(fileExtention) != -1))
            {
                return true;
            }

            return false;
        }

        public static string AddVersionToFileName(string filePath, string fileName)
        {
            int verNum = 0;

            string fileNameWithOutExtention = "";
            string fileExtention = "";
            GetFileParts(fileName, ref fileNameWithOutExtention, ref fileExtention);

            while ((File.Exists(filePath + fileName)))
            {
                fileName = fileNameWithOutExtention + "_" + verNum.ToString() + "." + fileExtention;
                verNum = verNum + 1;
            }

            return fileName;
        }

    }
}
