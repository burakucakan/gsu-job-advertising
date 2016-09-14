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

	public partial class UserFollowedFirms {
		
		#region ColumnNames
		public struct ColumnNames
		{
			                                        public const string ID="ID";
            public const string UserId="UserId";
            public const string FirmId="FirmId";
		}
		#endregion
		
		#region Create DataTable
		public static DataTable CreateTable()
{
	DataTable dt=new DataTable();
	
	            dt.Columns.Add("ID",System.Type.GetType("System.Int32"));
    dt.Columns.Add("UserId",System.Type.GetType("System.Int32"));
    dt.Columns.Add("FirmId",System.Type.GetType("System.Int32"));

	return dt;
}

		#endregion
		
		#region Bulk Operations
		public class BulkOperation
		{
		
		public static void Add(SqlTransaction tran,DataTable dt)
		{
			foreach(DataRow dr in dt.Rows)
			{
				Add(tran,dr);
			}
		}
		
		public static void Add(DataTable dt)
		{
			SqlConnection conn=null;
            SqlTransaction tran = null;

            try
            {
                conn = new SqlConnection(UserFollowedFirmsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);
			
				foreach(DataRow dr in dt.Rows)
				{
					Add(tran,dr);
				}
				
				//transaction Commit
                tran.Commit();

            }
            catch (Exception ex)
            {
                //transaction Rollback
                tran.Rollback();
				throw new MyException(ex.Message, "UserFollowedFirms", "Add");                
            }
            finally
            {
                //Connection Close
                conn.Close();
                conn.Dispose();
            }
			
		}
		
		public static void Update(SqlTransaction tran,DataTable dt)
		{
			foreach(DataRow dr in dt.Rows)
			{
				Update(tran,dr);
			}
		}
		
		public static void Update(DataTable dt)
		{
			SqlConnection conn=null;
            SqlTransaction tran = null;

            try
            {
                conn = new SqlConnection(UserFollowedFirmsProvider.GetConnectionString());
                conn.Open();

                tran = conn.BeginTransaction(IsolationLevel.Serializable);
			
				foreach(DataRow dr in dt.Rows)
				{
					Update(tran,dr);
				}
				
				//transaction Commit
                tran.Commit();

            }
            catch (Exception ex)
            {
                //transaction Rollback
                tran.Rollback();
				throw new MyException(ex.Message, "UserFollowedFirms", "Update");                
            }
            finally
            {
                //Connection Close
                conn.Close();
                conn.Dispose();
            }
		}
		
		public static int Add(DataRow dr)
{
	return UserFollowedFirmsProvider.Generated.Add(	    (int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.UserId], 
                                        (int)dr[ColumnNames.FirmId]);
	
}

public static int Add(SqlTransaction tran,DataRow dr)
{
	return UserFollowedFirmsProvider.Generated.Add(	tran,
										(int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.UserId], 
                                        (int)dr[ColumnNames.FirmId]);	

}

		public static int Update(DataRow dr)
{
	return UserFollowedFirmsProvider.Generated.Update(	                                        (int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.UserId], 
                                        (int)dr[ColumnNames.FirmId]);	
}

public static int Update(SqlTransaction tran,DataRow dr)
{
	return UserFollowedFirmsProvider.Generated.Update(	tran,
										(int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.UserId], 
                                        (int)dr[ColumnNames.FirmId]);
}
}
		#endregion
		
		public class Generated{
		
		#region Get Functions
		public static DataTable GetByParams(                                        int? id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.GetByParams(                                        id, userId, firmId)
.Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,                                        int? id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.GetByParams(tran,                                        id, userId, firmId)
.Tables[0];		
		}
		
		public static DataTable GetByParams(params SqlParameter[] sqlParams)
		{
        	return UserFollowedFirmsProvider.Generated.GetByParams(sqlParams).Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return UserFollowedFirmsProvider.Generated.GetByParams(tran,sqlParams).Tables[0];
		}
		
				
		
		public static DataTable GetAll(SqlTransaction tran)
		{
			return UserFollowedFirmsProvider.Generated.GetAll(tran).Tables[0];
		}
		
		public static DataTable GetAll()
		{
			return UserFollowedFirmsProvider.Generated.GetAll().Tables[0];
		}
		
		public static DataTable Get(SqlTransaction tran,                                        int id)
		{
			return UserFollowedFirmsProvider.Generated.Get(tran,                                        id)
.Tables[0];
		}
		
		public static DataTable Get(                                        int id)
		{
			return UserFollowedFirmsProvider.Generated.Get(                                        id)
.Tables[0];
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(                                        int id, int userId, int firmId)
		{
			return UserFollowedFirmsProvider.Generated.Update(                                        id, userId, firmId)
;
		}
		
		public static int Update(SqlTransaction tran,                                        int id, int userId, int firmId)
		{
			return UserFollowedFirmsProvider.Generated.Update(                                        id, userId, firmId)
;		
		}
		
		public static int UpdateByParams(                                        int id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.UpdateByParams(                                        id, userId, firmId)
;		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            return UserFollowedFirmsProvider.Generated.UpdateByParams(sqlParams);		
		}
		
		public static int UpdateByParams(SqlTransaction tran,                                        int id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.UpdateByParams(tran,                                        id, userId, firmId)
;		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return UserFollowedFirmsProvider.Generated.UpdateByParams(tran,sqlParams);		
		}
		#endregion
	
		#region Add Functions
				public static int Add(                                        int id, int userId, int firmId)
		{
			return UserFollowedFirmsProvider.Generated.Add(                                        id, userId, firmId)
;
		}
		
		public static int Add(SqlTransaction tran,                                        int id, int userId, int firmId)
		{
			return UserFollowedFirmsProvider.Generated.Add(tran,                                        id, userId, firmId)
;		
		}
		#endregion
	
		#region Delete Functions
		public static int DeleteByParams(                                        int? id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.DeleteByParams(null,                                        id, userId, firmId)
;
		}
		
		public static int DeleteByParams(SqlTransaction tran,                                        int? id, int? userId, int? firmId)
		{
			return UserFollowedFirmsProvider.Generated.DeleteByParams(tran,                                        id, userId, firmId)
;
		}
		
		public static int Delete(                                        int id)
		{
			return UserFollowedFirmsProvider.Generated.Delete(                                        id)
;
		}

		public static int Delete(SqlTransaction tran,                                        int id)
		{
			return UserFollowedFirmsProvider.Generated.Delete(tran,                                        id)
;		
		}
		
		

		#endregion

		}
	}
}
