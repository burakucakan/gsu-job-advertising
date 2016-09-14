using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS
{

    public partial class CVs
    {
        public struct AddErrorCodes
        {
            public const int HasSameNamedCv=-1;
        }

        #region CustomColumnNames
        public struct CustomColumnNames
        {
            public const string UserName = "UserName";
            public const string Surname = "Surname";
            public const string Birthdate="Birthdate";
            public const string Gender="Gender";
            public const string Address="Address";
            public const string StudentNumber="StudentNumber";
        }
        #endregion

        public static DataSet GetAllData(int cvId)
        {
            return CVsProvider.GetAllData(null,cvId);
        }

        public static int Add(DataRow drCv,DataTable dtCertificates,DataTable dtWorkPlaces,
            DataTable dtCourseInfo,DataTable dtExamInfo,DataTable dtExperienceInfo,DataTable dtLanguageInfo,
            DataTable dtInterestedPositions, DataTable dtReferances, DataTable dtUserClubs)
        {
            int cvId = 0;

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                DataTable dtCvs = CVs.Generated.GetByFK(tran, drCv[ColumnNames.UserId].ToInt());
                foreach (DataRow dr in dtCvs.Rows)
                {
                    if (dr[ColumnNames.Name].ToString() == drCv[ColumnNames.Name].ToString())
                        return -1;
                }
                
                if (dtCvs.Rows.Count == 0)
                    drCv[ColumnNames.IsDefault] = true;
                else
                    drCv[ColumnNames.IsDefault] = false;

                cvId=BulkOperation.Add(tran,drCv);

                foreach (DataRow dr in dtCertificates.Rows)
                    dr[CVs.CertificateInfo.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtWorkPlaces.Rows)
                    dr[CVs.PreferredWorkPlaces.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtCourseInfo.Rows)
                    dr[CVs.CourseInfo.ColumnNames.CVId] = cvId;
                
                foreach (DataRow dr in dtExamInfo.Rows)
                    dr[CVs.ExamInfo.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtExperienceInfo.Rows)
                    dr[CVs.WorkExperiences.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtLanguageInfo.Rows)
                    dr[CVs.LanguageInfo.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtInterestedPositions.Rows)
                    dr[CVs.InterestedJobPositions.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtReferances.Rows)
                    dr[CVs.Referances.ColumnNames.CVId] = cvId;

                foreach (DataRow dr in dtUserClubs.Rows)
                    dr[CVs.UnivercityClubs.ColumnNames.CVId] = cvId;

                CVs.CertificateInfo.BulkOperation.Add(tran, dtCertificates);
                CVs.PreferredWorkPlaces.BulkOperation.Add(tran,dtWorkPlaces);
                CVs.ExamInfo.BulkOperation.Add(tran,dtExamInfo);
                CVs.WorkExperiences.BulkOperation.Add(tran,dtExperienceInfo);
                CVs.LanguageInfo.BulkOperation.Add(tran,dtLanguageInfo);
                CVs.InterestedJobPositions.BulkOperation.Add(tran,dtInterestedPositions);
                CVs.Referances.BulkOperation.Add(tran,dtReferances);
                CVs.UnivercityClubs.BulkOperation.Add(tran,dtUserClubs);

                //transaction Commit
                tran.Commit();
            }
            catch (Exception ex)
            {
                Logger.LogErrors(ex.ToString());

                //transaction Rollback
                tran.Rollback();
                throw new MyException(ex, "CVs", "Add");
            }
            finally
            {
                //Connection Close
                conn.Close();
                conn.Dispose();
            }

            return cvId;
        }

        public class CVState
        {
            public const int Passive = 0;
            public const int Active = 1;
            public const int Deleted = 2;

            public static int Update(int cvId,int state,DateTime modifyDate)
            {
                return CVsProvider.UpdateCVState(null,cvId,state,modifyDate);
            }
        }
        public class GeneralInfo
        {
            public static int Update(int cvId,string name, int cvLanguage,DateTime modifyDate)
            {
                return CVsProvider.UpdateCVGeneralInfo(null, cvId, name, cvLanguage, modifyDate);
            }
        }

        public static DataTable GetDefaultCv(int UserId) {
            return CVs.Generated.GetByParams(new SqlParameter("UserId", UserId), new SqlParameter("IsDefault", true));
        }

        public static bool Delete(int CvId) {
            return BUS.CVs.Generated.UpdateByParams(
                new SqlParameter(ColumnNames.ID, CvId),
                new SqlParameter(ColumnNames.IsDefault, false),
                new SqlParameter(ColumnNames.ModifyDate, DateTime.Now),
                new SqlParameter(ColumnNames.CVState, CVState.Deleted)) > 0;
        }

        public static int UpdateCVAsDefault(SqlTransaction tran, int cvId, int userId, bool isDefault)
        {
            return CVs.UpdateCVAsDefault(null,cvId, userId, isDefault);
        }

        public static bool CvDefault(int UserId, int CvId)
        {
            return (CVsProvider.CvDefault(UserId, CvId) > 0);
        }
    }
}
