using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GSUKariyer.DAL;
using System.Collections;

namespace GSUKariyer.BUS {
    public class AdminPermissions
    {
        public static DataTable AdminPermissionsSel()
        {
            return AdminPermissionsProvider.AdminPermissionsSel();
        }

        public static bool AdminUserPermissionDel(int AdminID)
        {
            return AdminPermissionsProvider.AdminUserPermissionDel(AdminID);
        }

        public static DataTable AdminSel()
        {
            return AdminPermissionsProvider.AdminSel();
        }

        public static DataTable GetAdminUserPermission(int AdminID)
        {
            return AdminPermissionsProvider.GetAdminUserPermission(AdminID);
        }
        
        public static bool HasAdmins(string UserName)
        {
             return AdminPermissionsProvider.HasAdmins(UserName);
        }

        public static bool AdminUserNew(int AdminID, string UserName, string Password, string Firstname, string SurName, string Description, int ModifiedBy, bool IsActive, ArrayList arrAdminPermission)
        {
            SqlConnection conn = new SqlConnection(AdminPermissionsProvider.GetConnectionString());
            conn.Open();

            SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable);
            return AdminPermissionsProvider.AdminUserNew(tran, AdminID, UserName, Password, Firstname, SurName, Description, ModifiedBy, IsActive, arrAdminPermission);

        }

        public static DataTable GetAdmin(int AdminID)
        {
            return AdminPermissionsProvider.GetAdmin(AdminID);
        }

        public static bool AdminDel(ArrayList arrAdminID, int ModifiedBy)
        {
            SqlConnection conn = new SqlConnection(AdminPermissionsProvider.GetConnectionString());
            conn.Open();

            SqlTransaction tran = conn.BeginTransaction(IsolationLevel.Serializable);
            return AdminPermissionsProvider.AdminDel(tran, arrAdminID, ModifiedBy);
        }

    }
}