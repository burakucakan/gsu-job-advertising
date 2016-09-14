using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GSUKariyer.COMMON;
using GSUKariyer.COMMON.Helpers.DAL;
using System.Collections;

namespace GSUKariyer.DAL
{
    public class AdminPermissionsProvider : BaseDataLayer
    {
        public static DataTable AdminPermissionsSel()
        {            
            try
            {
                return ExecuteDataset("BGA_CustomAdminPermissionsSel").Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AdminUserPermissionDel(int AdminID)
        {            
            try
            {
                ExecuteNonQuery("BGA_CustomAdminUserPermissionDel", new SqlParameter("@AdminID", AdminID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable AdminSel()
        {            
            try
            {
                return ExecuteDataset("BGA_CustomAdminSel").Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DataTable GetAdminUserPermission(int AdminID)
        {            
            try
            {
                return ExecuteDataset("BGA_CustomGetAdminUserPermission", new SqlParameter("@AdminID", AdminID)).Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool HasAdmins(string UserName)
        {            
            try
            {
                return (Convert.ToInt32((ExecuteScalar("BGA_CustomHasAdmin", new SqlParameter("@UserName", Util.r(UserName.Trim()))))) > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AdminUserNew(SqlTransaction tran, int AdminID, string UserName, string Password, string Firstname, string SurName, string Description, int ModifiedBy, bool IsActive, ArrayList arrAdminPermission)
        {            
            try
            {

                bool Exec;

                if (AdminID < 1)
                    Exec = int.TryParse(ExecuteScalar(tran, "BGA_CustomAdminsIn",
                                        new SqlParameter("@UserName", Util.r(UserName.Trim())),
                                        new SqlParameter("@Password", Encryption.Encrypt(Util.r(Password.Trim()))),
                                        new SqlParameter("@Firstname", Util.r(Firstname)),
                                        new SqlParameter("@SurName", Util.r(SurName)),
                                        new SqlParameter("@Description", Util.r(Description)),
                                        new SqlParameter("@IsActive", IsActive)
                                        ).ToString(), out AdminID);
                else
                {
                    SqlHelper.ExecuteScalar(tran, "BGA_CustomAdminsUp",
                                        new SqlParameter("@AdminID", AdminID),
                                        new SqlParameter("@Password", Encryption.Encrypt(Util.r(Password.Trim()))),
                                        new SqlParameter("@Firstname", Util.r(Firstname)),
                                        new SqlParameter("@SurName", Util.r(SurName)),
                                        new SqlParameter("@Description", Util.r(Description)),
                                        new SqlParameter("@ModifiedBy", ModifiedBy),
                                        new SqlParameter("@IsActive", IsActive)
                                        );
                    Exec = true;
                }

                if (Exec)
                {

                    SqlHelper.ExecuteNonQuery(tran, "BGA_CustomAdminUserPermissionDel", new SqlParameter("@AdminID", AdminID));

                    for (int i = 0; i < arrAdminPermission.Count; i++)
                    {
                        if (Util.IsNumeric(arrAdminPermission[i]))
                        {
                            SqlHelper.ExecuteNonQuery(tran, "BGA_CustomAdminUserPermissionsIn",
                            new SqlParameter("@AdminID", AdminID),
                            new SqlParameter("@AdminPermissionID", arrAdminPermission[i])
                            );
                        }
                    }
                    tran.Commit();
                }
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }

        public static DataTable GetAdmin(int AdminID)
        {
            
            try
            {
                return ExecuteDataset("BGA_CustomGetAdmin", new SqlParameter("@AdminID", AdminID)).Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AdminDel(SqlTransaction tran, ArrayList arrAdminID, int ModifiedBy)
        {
            try
            {
                for (int i = 0; i < arrAdminID.Count; i++)
                {
                    if (Util.IsNumeric(arrAdminID[i]))
                    {
                        SqlHelper.ExecuteNonQuery(tran, "BGA_CustomAdminsDel",
                        new SqlParameter("@AdminID", arrAdminID[i]),
                        new SqlParameter("@ModifiedBy", ModifiedBy)
                        );
                    }
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
