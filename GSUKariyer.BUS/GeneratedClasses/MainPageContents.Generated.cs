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

	public partial class MainPageContents {
		
		#region ColumnNames
		public struct ColumnNames
		{
			                                        public const string ID="ID";
            public const string MainPageRegion="MainPageRegion";
            public const string ContentType="ContentType";
            public const string ContentId="ContentId";
            public const string ContentOrder="ContentOrder";
            public const string ModifyDate="ModifyDate";
            public const string CreateDate="CreateDate";
		}
		#endregion
		
		#region Create DataTable
		public static DataTable CreateTable()
{
	DataTable dt=new DataTable();
	
	            dt.Columns.Add("ID",System.Type.GetType("System.Int32"));
    dt.Columns.Add("MainPageRegion",System.Type.GetType("System.Int32"));
    dt.Columns.Add("ContentType",System.Type.GetType("System.Int32"));
    dt.Columns.Add("ContentId",System.Type.GetType("System.Int32"));
    dt.Columns.Add("ContentOrder",System.Type.GetType("System.Int32"));
    dt.Columns.Add("ModifyDate",System.Type.GetType("System.DateTime"));
    dt.Columns.Add("CreateDate",System.Type.GetType("System.DateTime"));

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
                conn = new SqlConnection(MainPageContentsProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "MainPageContents", "Add");                
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
                conn = new SqlConnection(MainPageContentsProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "MainPageContents", "Update");                
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
	return MainPageContentsProvider.Generated.Add(	    (int)dr[ColumnNames.MainPageRegion], 
                                        (int)dr[ColumnNames.ContentType], 
                                        (int)dr[ColumnNames.ContentId], 
                                        (int)dr[ColumnNames.ContentOrder], 
                                        (DateTime)dr[ColumnNames.ModifyDate], 
                                        (DateTime)dr[ColumnNames.CreateDate]);
	
}

public static int Add(SqlTransaction tran,DataRow dr)
{
	return MainPageContentsProvider.Generated.Add(	tran,
										(int)dr[ColumnNames.MainPageRegion], 
                                        (int)dr[ColumnNames.ContentType], 
                                        (int)dr[ColumnNames.ContentId], 
                                        (int)dr[ColumnNames.ContentOrder], 
                                        (DateTime)dr[ColumnNames.ModifyDate], 
                                        (DateTime)dr[ColumnNames.CreateDate]);	

}

		public static int Update(DataRow dr)
{
	return MainPageContentsProvider.Generated.Update(	                                        (int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.MainPageRegion], 
                                        (int)dr[ColumnNames.ContentType], 
                                        (int)dr[ColumnNames.ContentId], 
                                        (int)dr[ColumnNames.ContentOrder], 
                                        (DateTime)dr[ColumnNames.ModifyDate]);	
}

public static int Update(SqlTransaction tran,DataRow dr)
{
	return MainPageContentsProvider.Generated.Update(	tran,
										(int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.MainPageRegion], 
                                        (int)dr[ColumnNames.ContentType], 
                                        (int)dr[ColumnNames.ContentId], 
                                        (int)dr[ColumnNames.ContentOrder], 
                                        (DateTime)dr[ColumnNames.ModifyDate]);
}
}
		#endregion
		
		public class Generated{
		
		#region Get Functions
		public static DataTable GetByParams(                                        int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return MainPageContentsProvider.Generated.GetByParams(                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
.Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,                                        int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return MainPageContentsProvider.Generated.GetByParams(tran,                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
.Tables[0];		
		}
		
		public static DataTable GetByParams(params SqlParameter[] sqlParams)
		{
        	return MainPageContentsProvider.Generated.GetByParams(sqlParams).Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return MainPageContentsProvider.Generated.GetByParams(tran,sqlParams).Tables[0];
		}
		
				
		
		public static DataTable GetAll(SqlTransaction tran)
		{
			return MainPageContentsProvider.Generated.GetAll(tran).Tables[0];
		}
		
		public static DataTable GetAll()
		{
			return MainPageContentsProvider.Generated.GetAll().Tables[0];
		}
		
		public static DataTable Get(SqlTransaction tran,                                        int id)
		{
			return MainPageContentsProvider.Generated.Get(tran,                                        id)
.Tables[0];
		}
		
		public static DataTable Get(                                        int id)
		{
			return MainPageContentsProvider.Generated.Get(                                        id)
.Tables[0];
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(                                        int id, int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate)
		{
			return MainPageContentsProvider.Generated.Update(                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate)
;
		}
		
		public static int Update(SqlTransaction tran,                                        int id, int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate)
		{
			return MainPageContentsProvider.Generated.Update(                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate)
;		
		}
		
		public static int UpdateByParams(                                        int id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? createDate)
		{
			return MainPageContentsProvider.Generated.UpdateByParams(                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, createDate)
;		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            return MainPageContentsProvider.Generated.UpdateByParams(sqlParams);		
		}
		
		public static int UpdateByParams(SqlTransaction tran,                                        int id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? createDate)
		{
			return MainPageContentsProvider.Generated.UpdateByParams(tran,                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, createDate)
;		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return MainPageContentsProvider.Generated.UpdateByParams(tran,sqlParams);		
		}
		#endregion
	
		#region Add Functions
				public static int Add(                                        int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate, DateTime createDate)
		{
			return MainPageContentsProvider.Generated.Add(                                        mainPageRegion, contentType, contentId, contentOrder, modifyDate, createDate)
;
		}
		
		public static int Add(SqlTransaction tran,                                        int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate, DateTime createDate)
		{
			return MainPageContentsProvider.Generated.Add(tran,                                        mainPageRegion, contentType, contentId, contentOrder, modifyDate, createDate)
;		
		}
		#endregion
	
		#region Delete Functions
		public static int DeleteByParams(                                        int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return MainPageContentsProvider.Generated.DeleteByParams(null,                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
;
		}
		
		public static int DeleteByParams(SqlTransaction tran,                                        int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return MainPageContentsProvider.Generated.DeleteByParams(tran,                                        id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
;
		}
		
		public static int Delete(                                        int id)
		{
			return MainPageContentsProvider.Generated.Delete(                                        id)
;
		}

		public static int Delete(SqlTransaction tran,                                        int id)
		{
			return MainPageContentsProvider.Generated.Delete(tran,                                        id)
;		
		}
		
		

		#endregion

		}
	}
}
