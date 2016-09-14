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

	public partial class CVUniversityClubs {
		
		#region ColumnNames
		public struct ColumnNames
		{
			                                        public const string CVId="CVId";
            public const string UniversityClub="UniversityClub";
		}
		#endregion
		
		#region Create DataTable
		public static DataTable CreateTable()
{
	DataTable dt=new DataTable();
	
	            dt.Columns.Add("CVId",System.Type.GetType("System.Int32"));
    dt.Columns.Add("UniversityClub",System.Type.GetType("System.Int32"));

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
                conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "CVUniversityClubs", "Add");                
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
                conn = new SqlConnection(CVUniversityClubsProvider.GetConnectionString());
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
				throw new MyException(ex.Message, "CVUniversityClubs", "Update");                
            }
            finally
            {
                //Connection Close
                conn.Close();
                conn.Dispose();
            }
		}
		
		public static object Add(DataRow dr)
{
	return CVUniversityClubsProvider.Generated.Add(	    (int)dr[ColumnNames.CVId], 
                                        (int)dr[ColumnNames.UniversityClub]);
	
}

public static object Add(SqlTransaction tran,DataRow dr)
{
	return CVUniversityClubsProvider.Generated.Add(	tran,
										(int)dr[ColumnNames.CVId], 
                                        (int)dr[ColumnNames.UniversityClub]);	

}

		public static int Update(DataRow dr)
{
	return CVUniversityClubsProvider.Generated.Update(	                                        (int)dr[ColumnNames.CVId], 
                                        (int)dr[ColumnNames.UniversityClub]);	
}

public static int Update(SqlTransaction tran,DataRow dr)
{
	return CVUniversityClubsProvider.Generated.Update(	tran,
										(int)dr[ColumnNames.CVId], 
                                        (int)dr[ColumnNames.UniversityClub]);
}
}
		#endregion
		
		public class Generated{
		
		#region Get Functions
		public static DataTable GetByParams(                                        int? cVId, int? universityClub)
		{
			return CVUniversityClubsProvider.Generated.GetByParams(                                        cVId, universityClub)
.Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,                                        int? cVId, int? universityClub)
		{
			return CVUniversityClubsProvider.Generated.GetByParams(tran,                                        cVId, universityClub)
.Tables[0];		
		}
		
		public static DataTable GetByParams(params SqlParameter[] sqlParams)
		{
        	return CVUniversityClubsProvider.Generated.GetByParams(sqlParams).Tables[0];
		}
		
		public static DataTable GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return CVUniversityClubsProvider.Generated.GetByParams(tran,sqlParams).Tables[0];
		}
		
				
		
		public static DataTable GetAll(SqlTransaction tran)
		{
			return CVUniversityClubsProvider.Generated.GetAll(tran).Tables[0];
		}
		
		public static DataTable GetAll()
		{
			return CVUniversityClubsProvider.Generated.GetAll().Tables[0];
		}
		
		public static DataTable Get(SqlTransaction tran,                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Get(tran,                                        cVId, universityClub)
.Tables[0];
		}
		
		public static DataTable Get(                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Get(                                        cVId, universityClub)
.Tables[0];
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Update(                                        cVId, universityClub)
;
		}
		
		public static int Update(SqlTransaction tran,                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Update(                                        cVId, universityClub)
;		
		}
		
		public static int UpdateByParams(                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.UpdateByParams(                                        cVId, universityClub)
;		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            return CVUniversityClubsProvider.Generated.UpdateByParams(sqlParams);		
		}
		
		public static int UpdateByParams(SqlTransaction tran,                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.UpdateByParams(tran,                                        cVId, universityClub)
;		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            return CVUniversityClubsProvider.Generated.UpdateByParams(tran,sqlParams);		
		}
		#endregion
	
		#region Add Functions
				public static object Add(                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Add(                                        cVId, universityClub)
;
		}
		
		public static object Add(SqlTransaction tran,                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Add(tran,                                        cVId, universityClub)
;		
		}
		#endregion
	
		#region Delete Functions
		public static int DeleteByParams(                                        int? cVId, int? universityClub)
		{
			return CVUniversityClubsProvider.Generated.DeleteByParams(null,                                        cVId, universityClub)
;
		}
		
		public static int DeleteByParams(SqlTransaction tran,                                        int? cVId, int? universityClub)
		{
			return CVUniversityClubsProvider.Generated.DeleteByParams(tran,                                        cVId, universityClub)
;
		}
		
		public static int Delete(                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Delete(                                        cVId, universityClub)
;
		}

		public static int Delete(SqlTransaction tran,                                        int cVId, int universityClub)
		{
			return CVUniversityClubsProvider.Generated.Delete(tran,                                        cVId, universityClub)
;		
		}
		
		

		#endregion

		}
	}
}
