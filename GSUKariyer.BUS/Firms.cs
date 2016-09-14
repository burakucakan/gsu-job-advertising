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

	public partial class Firms
    {
        public enum WorkerCount
        {
            wc_0_25 = 1,
            wc_25_50 = 2,
            wc_50_100 = 3,
            wc_100_500 = 4,
            wc_500_1000 = 5,
            wc_1000uzeri = 6
        }

        #region Get Functions

        public static DataTable Login(string Email, string Password)
        {
            return FirmsProvider.Login(Email, Password).Tables[0];
        }

        public static DataTable GetPendingFirms()
        {
            return Firms.Generated.GetByParams(
                            new SqlParameter(ColumnNames.IsActive, false), 
                            new SqlParameter(ColumnNames.IsDeleted, false)
                            );
        }

        public static DataTable GetAll() { 
            return FirmsProvider.Generated.GetByParams(
                new SqlParameter(ColumnNames.IsDeleted, false),
                new SqlParameter(ColumnNames.IsActive, true)
                ).Tables[0];
        }

        #endregion

        #region Update Functions


        public static int Save(int FirmId, string Name, string SectorValue, int WorkerCount, string Address, string ZipCode, int Country, int City, string WebPage, string Description,
                int FirmUserId, string FirmUserName, string FirmUserSurname, string Position, string Phone, string Fax, string Email, string Password)
        {

            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = new SqlConnection(FirmsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);

                int ReturnFirmId = 0;

                if (FirmId < 1)
                {
                    int IdentityFirmId = Firms.Generated.Add(tran, Name, SectorValue, WorkerCount, Address, ZipCode, Country, City, Description, WebPage, false, null, DateTime.Now, DateTime.Now, false);
                    int IdentityFirmUserId = FirmUsers.Generated.Add(tran, IdentityFirmId, FirmUserName, FirmUserSurname, Position, Phone, null, Fax, Email, Password, null, DateTime.Now, null, DateTime.Now, null);
                    ReturnFirmId = IdentityFirmId;
                }
                else 
                {
                    Firms.Generated.UpdateByParams(tran,
                        new SqlParameter(ColumnNames.ID, FirmId),
                        new SqlParameter(ColumnNames.Name, Name),
                        new SqlParameter(ColumnNames.Sector, SectorValue),
                        new SqlParameter(ColumnNames.WorkerCount, WorkerCount),
                        new SqlParameter(ColumnNames.Address, Address),
                        new SqlParameter(ColumnNames.Zipcode, ZipCode),
                        new SqlParameter(ColumnNames.Country, Country),
                        new SqlParameter(ColumnNames.City, City),
                        new SqlParameter(ColumnNames.Webpage, WebPage),
                        new SqlParameter(ColumnNames.Description, Description),
                        new SqlParameter(ColumnNames.ModifyDate, DateTime.Now));
                    
                    FirmUsers.Generated.UpdateByParams(tran,
                        new SqlParameter(FirmUsers.ColumnNames.ID, FirmUserId),
                        new SqlParameter(FirmUsers.ColumnNames.Name, FirmUserName),
                        new SqlParameter(FirmUsers.ColumnNames.Surname, FirmUserSurname),
                        new SqlParameter(FirmUsers.ColumnNames.Position, Position),
                        new SqlParameter(FirmUsers.ColumnNames.Phone, Phone),
                        new SqlParameter(FirmUsers.ColumnNames.Fax, Fax),
                        new SqlParameter(FirmUsers.ColumnNames.Password, Password));

                    ReturnFirmId = FirmId;
                }

                tran.Commit();

                return ReturnFirmId;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new MyException(ex, "Firms", "Update");                
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return 0;
        }


        public static bool Active(int FirmId) { 
            return FirmsProvider.Generated.UpdateByParams(
                new SqlParameter(ColumnNames.ID, FirmId),
                new SqlParameter(ColumnNames.IsActive, true)
            ) > 0;
        }

        #endregion

        public class Advertisements
        { 
            public static DataTable GetActiveOnes(int firmId)
            {
                return AdvertisementsProvider.GetFirmActiveAdvertisements(DateTime.Now,firmId).Tables[0];
            }
        }

        public static bool Delete(ArrayList arrIDs, int ModifiedBy)
        {
            SqlConnection conn = new SqlConnection(AdminPermissionsProvider.GetConnectionString());
            conn.Open();

            SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                for (int i = 0; i < arrIDs.Count; i++)
                {
                    if (Util.IsNumeric(arrIDs[i]))
                        FirmsProvider.Generated.UpdateByParams(tran, 
                            new SqlParameter(ColumnNames.ID, arrIDs[i]),
                            new SqlParameter(ColumnNames.IsDeleted, true));
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }
    }
}
