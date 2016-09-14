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

	public partial class FirmMessageTemplates {
		
		#region ColumnNames
		public struct ColumnNames
		{
			                                        public const string ID="ID";
            public const string FirmId="FirmId";
            public const string Content="Content";
		}
		#endregion
		
		#region Create DataTable
		public static DataTable CreateTable()
{
	DataTable dt=new DataTable();
	
	            dt.Columns.Add("ID",System.Type.GetType("System.Int32"));
    dt.Columns.Add("FirmId",System.Type.GetType("System.Int32"));
    dt.Columns.Add("Content",System.Type.GetType("System.String"));

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
                conn = new SqlConnection(FirmMessageTemplatesProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "FirmMessageTemplates", "Add");                
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
                conn = new SqlConnection(FirmMessageTemplatesProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "FirmMessageTemplates", "Update");                
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
	return FirmMessageTemplatesProvider.Generated.Add(	    (int)dr[ColumnNames.FirmId], 
                                        dr[ColumnNames.Content].ToString());
	
}

public static int Add(SqlTransaction tran,DataRow dr)
{
	return FirmMessageTemplatesProvider.Generated.Add(	tran,
										(int)dr[ColumnNames.FirmId], 
                                        dr[ColumnNames.Content].ToString());	

}

		public static int Update(DataRow dr)
{
	return FirmMessageTemplatesProvider.Generated.Update(	                                        (int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.FirmId], 
                                        dr[ColumnNames.Content].ToString());	
}

public static int Update(SqlTransaction tran,DataRow dr)
{
	return FirmMessageTemplatesProvider.Generated.Update(	tran,
										(int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.FirmId], 
                                        dr[ColumnNames.Content].ToString());
}
}
		#endregion
		
		public class Generated{
		
		#region Get Functions
		public static DataTable GetByParams(                                        int? id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.GetByParams(                                        id, firmId, content)
.Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,                                        int? id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.GetByParams(tran,                                        id, firmId, content)
.Tables[0];		
		}
		
		public static DataTable GetByParams(params SqlParameter[] sqlParams)
		{
        	return FirmMessageTemplatesProvider.Generated.GetByParams(sqlParams).Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return FirmMessageTemplatesProvider.Generated.GetByParams(tran,sqlParams).Tables[0];
		}
		
				
		
		public static DataTable GetAll(SqlTransaction tran)
		{
			return FirmMessageTemplatesProvider.Generated.GetAll(tran).Tables[0];
		}
		
		public static DataTable GetAll()
		{
			return FirmMessageTemplatesProvider.Generated.GetAll().Tables[0];
		}
		
		public static DataTable Get(SqlTransaction tran,                                        int id)
		{
			return FirmMessageTemplatesProvider.Generated.Get(tran,                                        id)
.Tables[0];
		}
		
		public static DataTable Get(                                        int id)
		{
			return FirmMessageTemplatesProvider.Generated.Get(                                        id)
.Tables[0];
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(                                        int id, int firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.Update(                                        id, firmId, content)
;
		}
		
		public static int Update(SqlTransaction tran,                                        int id, int firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.Update(                                        id, firmId, content)
;		
		}
		
		public static int UpdateByParams(                                        int id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.UpdateByParams(                                        id, firmId, content)
;		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            return FirmMessageTemplatesProvider.Generated.UpdateByParams(sqlParams);		
		}
		
		public static int UpdateByParams(SqlTransaction tran,                                        int id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.UpdateByParams(tran,                                        id, firmId, content)
;		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return FirmMessageTemplatesProvider.Generated.UpdateByParams(tran,sqlParams);		
		}
		#endregion
	
		#region Add Functions
				public static int Add(                                        int firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.Add(                                        firmId, content)
;
		}
		
		public static int Add(SqlTransaction tran,                                        int firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.Add(tran,                                        firmId, content)
;		
		}
		#endregion
	
		#region Delete Functions
		public static int DeleteByParams(                                        int? id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.DeleteByParams(null,                                        id, firmId, content)
;
		}
		
		public static int DeleteByParams(SqlTransaction tran,                                        int? id, int? firmId, string content)
		{
			return FirmMessageTemplatesProvider.Generated.DeleteByParams(tran,                                        id, firmId, content)
;
		}
		
		public static int Delete(                                        int id)
		{
			return FirmMessageTemplatesProvider.Generated.Delete(                                        id)
;
		}

		public static int Delete(SqlTransaction tran,                                        int id)
		{
			return FirmMessageTemplatesProvider.Generated.Delete(tran,                                        id)
;		
		}
		
		

		#endregion

		}
	}
}
