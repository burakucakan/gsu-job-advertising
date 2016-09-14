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

	public partial class CVCourseInfo {
		
		#region ColumnNames
		public struct ColumnNames
		{
			                                        public const string ID="ID";
            public const string CVId="CVId";
            public const string Name="Name";
            public const string Institution="Institution";
            public const string StartDate="StartDate";
            public const string EndDate="EndDate";
            public const string DurationInHours="DurationInHours";
            public const string Description="Description";
		}
		#endregion
		
		#region Create DataTable
		public static DataTable CreateTable()
{
	DataTable dt=new DataTable();
	
	            dt.Columns.Add("ID",System.Type.GetType("System.Int32"));
    dt.Columns.Add("CVId",System.Type.GetType("System.Int32"));
    dt.Columns.Add("Name",System.Type.GetType("System.String"));
    dt.Columns.Add("Institution",System.Type.GetType("System.String"));
    dt.Columns.Add("StartDate",System.Type.GetType("System.DateTime"));
    dt.Columns.Add("EndDate",System.Type.GetType("System.DateTime"));
    dt.Columns.Add("DurationInHours",System.Type.GetType("System.Int32"));
    dt.Columns.Add("Description",System.Type.GetType("System.String"));

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
                conn = new SqlConnection(CVCourseInfoProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "CVCourseInfo", "Add");                
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
                conn = new SqlConnection(CVCourseInfoProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "CVCourseInfo", "Update");                
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
	return CVCourseInfoProvider.Generated.Add(	    (int)dr[ColumnNames.CVId], 
                                        dr[ColumnNames.Name].ToString(), 
                                        dr[ColumnNames.Institution].ToString(), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]), 
                                        DBNullHelper.GetNullableValue<int>(dr[ColumnNames.DurationInHours]), 
                                        dr[ColumnNames.Description].ToString());
	
}

public static int Add(SqlTransaction tran,DataRow dr)
{
	return CVCourseInfoProvider.Generated.Add(	tran,
										(int)dr[ColumnNames.CVId], 
                                        dr[ColumnNames.Name].ToString(), 
                                        dr[ColumnNames.Institution].ToString(), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]), 
                                        DBNullHelper.GetNullableValue<int>(dr[ColumnNames.DurationInHours]), 
                                        dr[ColumnNames.Description].ToString());	

}

		public static int Update(DataRow dr)
{
	return CVCourseInfoProvider.Generated.Update(	                                        (int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.CVId], 
                                        dr[ColumnNames.Name].ToString(), 
                                        dr[ColumnNames.Institution].ToString(), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]), 
                                        DBNullHelper.GetNullableValue<int>(dr[ColumnNames.DurationInHours]), 
                                        dr[ColumnNames.Description].ToString());	
}

public static int Update(SqlTransaction tran,DataRow dr)
{
	return CVCourseInfoProvider.Generated.Update(	tran,
										(int)dr[ColumnNames.ID], 
                                        (int)dr[ColumnNames.CVId], 
                                        dr[ColumnNames.Name].ToString(), 
                                        dr[ColumnNames.Institution].ToString(), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.StartDate]), 
                                        DBNullHelper.GetNullableValue<DateTime>(dr[ColumnNames.EndDate]), 
                                        DBNullHelper.GetNullableValue<int>(dr[ColumnNames.DurationInHours]), 
                                        dr[ColumnNames.Description].ToString());
}
}
		#endregion
		
		public class Generated{
		
		#region Get Functions
		public static DataTable GetByParams(                                        int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.GetByParams(                                        id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
.Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,                                        int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.GetByParams(tran,                                        id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
.Tables[0];		
		}
		
		public static DataTable GetByParams(params SqlParameter[] sqlParams)
		{
        	return CVCourseInfoProvider.Generated.GetByParams(sqlParams).Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return CVCourseInfoProvider.Generated.GetByParams(tran,sqlParams).Tables[0];
		}
		
						public static DataTable GetByFKBasic(                                        int? cVId)
		{
			return CVCourseInfoProvider.Generated.GetByFKBasic(                                        cVId)
.Tables[0];
		}
		
public static DataTable GetByFKBasic(SqlTransaction tran,                                        int? cVId)
		{
			return CVCourseInfoProvider.Generated.GetByFKBasic(tran,                                        cVId)
.Tables[0];		
		}
		
		
		public static DataTable GetAll(SqlTransaction tran)
		{
			return CVCourseInfoProvider.Generated.GetAll(tran).Tables[0];
		}
		
		public static DataTable GetAll()
		{
			return CVCourseInfoProvider.Generated.GetAll().Tables[0];
		}
		
		public static DataTable Get(SqlTransaction tran,                                        int id)
		{
			return CVCourseInfoProvider.Generated.Get(tran,                                        id)
.Tables[0];
		}
		
		public static DataTable Get(                                        int id)
		{
			return CVCourseInfoProvider.Generated.Get(                                        id)
.Tables[0];
		}
		
				public static DataTable GetByFK(SqlTransaction tran,                                        int cVId)
		{
			return CVCourseInfoProvider.Generated.GetByFK(tran,                                        cVId)
.Tables[0];
		}
		
public static DataTable GetByFK(                                        int cVId)
		{
			return CVCourseInfoProvider.Generated.GetByFK(                                        cVId)
.Tables[0];
		}
		
			
		#endregion
	
		#region Update Functions
		public static int Update(                                        int id, int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.Update(                                        id, cVId, name, institution, startDate, endDate, durationInHours, description)
;
		}
		
		public static int Update(SqlTransaction tran,                                        int id, int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.Update(                                        id, cVId, name, institution, startDate, endDate, durationInHours, description)
;		
		}
		
		public static int UpdateByParams(                                        int id, int? cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.UpdateByParams(                                        id, cVId, name, institution, startDate, endDate, durationInHours, description)
;		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            return CVCourseInfoProvider.Generated.UpdateByParams(sqlParams);		
		}
		
		public static int UpdateByParams(SqlTransaction tran,                                        int id, int? cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.UpdateByParams(tran,                                        id, cVId, name, institution, startDate, endDate, durationInHours, description)
;		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return CVCourseInfoProvider.Generated.UpdateByParams(tran,sqlParams);		
		}
		#endregion
	
		#region Add Functions
				public static int Add(                                        int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.Add(                                        cVId, name, institution, startDate, endDate, durationInHours, description)
;
		}
		
		public static int Add(SqlTransaction tran,                                        int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.Add(tran,                                        cVId, name, institution, startDate, endDate, durationInHours, description)
;		
		}
		#endregion
	
		#region Delete Functions
		public static int DeleteByParams(                                        int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.DeleteByParams(null,                                        id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
;
		}
		
		public static int DeleteByParams(SqlTransaction tran,                                        int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return CVCourseInfoProvider.Generated.DeleteByParams(tran,                                        id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
;
		}
		
		public static int Delete(                                        int id)
		{
			return CVCourseInfoProvider.Generated.Delete(                                        id)
;
		}

		public static int Delete(SqlTransaction tran,                                        int id)
		{
			return CVCourseInfoProvider.Generated.Delete(tran,                                        id)
;		
		}
		
				public static int DeleteByFK(                                        int? cVId)
		{
			return CVCourseInfoProvider.Generated.DeleteByFK(                                        cVId)
;
		}
		
		public static int DeleteByFK(SqlTransaction tran,                                        int? cVId)
		{
			return CVCourseInfoProvider.Generated.DeleteByFK(                                        cVId)
;		
		}
		

		#endregion

		}
	}
}
