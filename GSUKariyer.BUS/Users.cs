using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.DAL;
using GSUKariyer.COMMON.Exceptions;
using GSUKariyer.COMMON;

namespace GSUKariyer.BUS {

	public partial class Users
    {
        #region Enums
        public enum Gender
        {
            Male=0,
            Female=1
        }
        public enum MaritalStatus
        {
            Single=0,
            Married=1,
            Widowed=2
        }
        public enum AgeCriteria
        {
            NoCriteria=0,
            Below17=17,
            Above20=20,
            Above22=22,
            Above24=24,
            Above26=26
        }
        #endregion

        #region Custom Column Names
        public struct CustomColumnNames
        {
            public const string UserId = "UserId";
            public const string UserName = "UserName";
        }
        #endregion

        #region Get Functions

        public static bool HasUser(string StudentNumber)
        {
            return Users.Generated.GetByParams(new SqlParameter("StudentNumber", StudentNumber),
                new SqlParameter("IsDeleted", false)).Rows.Count > 0;            
        }

        public static DataTable UserLogin(string StudentNumber, string Password)
        {
            return UsersProvider.UserLogin(StudentNumber, Password).Tables[0];
        }

        public static DataTable GetUserByStudentNumber(string StudentNumber)
        {
            return Users.Generated.GetByParams(
                            new SqlParameter("StudentNumber", StudentNumber),
                            new SqlParameter(ColumnNames.IsActive, true),
                            new SqlParameter(ColumnNames.IsDeleted, false)
                            );
        }

        public static int GetAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        public static DataTable GetAll(bool? isDeleted)
        {
            return Users.Generated.GetByParams(new SqlParameter("IsDeleted", false));            
        }

        #endregion

        #region Update Functions

        public static bool UserActivate(string ActivationCode)
        {
            return UsersProvider.UserActivate(ActivationCode);
        }

        public static bool Update(int UserId, string Name, string Surname, string StudentNumber, int Gender, DateTime BirthDate, int Country, int City, string Address, string Email, string Password)
        {
            return Generated.UpdateByParams(
                new SqlParameter("ID", UserId),
                new SqlParameter("Name", Name),
                new SqlParameter("Surname", Surname),
                new SqlParameter("StudentNumber", StudentNumber),
                new SqlParameter("BirthDate", BirthDate),
                new SqlParameter("Country", Country),
                new SqlParameter("City", City),
                new SqlParameter("Address", Address),
                new SqlParameter("Gender", Gender),
                new SqlParameter("Email", Email),
                new SqlParameter("Password", Password),
                new SqlParameter("ModifyDate", DateTime.Now)
                ) > 0;
        }

        public static bool Update(int userId, string email, bool isActive)
        {
            return Generated.UpdateByParams(
                new SqlParameter("ID", userId),
                new SqlParameter("Email", email),
                new SqlParameter("IsActive",isActive),
                new SqlParameter("ModifyDate", DateTime.Now)
                ) > 0;
        }

        public static bool Update(int userId, string activationCode,DateTime activationDate)
        {
            return Generated.UpdateByParams(
                new SqlParameter("ID", userId),
                new SqlParameter("ActivationCode", activationCode),
                new SqlParameter("ActivationDate", activationDate)
                ) > 0;
        }

        #endregion

        #region Delete Functions
        public static int CustomDelete(int userId)
        {
            return UsersProvider.CustomDelete(null,userId);
        }
        public static bool Delete(ArrayList arrIDs, int ModifiedBy)
        {
            SqlConnection conn = null;
            SqlTransaction tran=null;

            try
            {
                conn = new SqlConnection(AdminPermissionsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                for (int i = 0; i < arrIDs.Count; i++)
                {
                    if (Util.IsNumeric(arrIDs[i]))
                        UsersProvider.CustomDelete(tran, (int)arrIDs[i]);
                }

                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        #endregion

        public class Cv
        {
            public static DataTable Get(int userId)
            {
                return CVsProvider.Generated.GetByFK(userId).Tables[0];
            }
        }
    }
}