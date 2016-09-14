using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class CVUniversityClubsProvider:BaseDataLayer {
		
		public class Generated{
		
		#region Get Functions
		protected static DataSet GetBasic(SqlTransaction tran,int? cVId, int? universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetCVUniversityClubs", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetCVUniversityClubs", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Get", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(int? cVId, int? universityClub)
		{
			return GetByParams(null,cVId, universityClub)
;
		}
		
		public static DataSet GetByParams(SqlTransaction tran,int? cVId, int? universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetCVUniversityClubsByParams", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetCVUniversityClubsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "GetByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(params SqlParameter[] sqlParams)
		{
        	return GetByParams(null,sqlParams);
		}
		
		public static DataSet GetByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {
                DataSet ds = null;

                ds = ExecuteDataset("BGA_GetCVUniversityClubsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "GetByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
				
		
		public static DataSet GetAll(SqlTransaction tran)
		{
			return GetBasic(tran,null, null);
		}
		
		public static DataSet GetAll()
		{
			return GetBasic(null,null, null);
		}
		
		public static DataSet Get(SqlTransaction tran,int cVId, int universityClub)
		{
			return GetBasic(tran,cVId, universityClub);
		}
		
		public static DataSet Get(int cVId, int universityClub)
		{
			return GetBasic(null,cVId, universityClub);
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery("BGA_UpdateCVUniversityClubs", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Update(SqlTransaction tran,int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateCVUniversityClubs", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery("BGA_UpdateCVUniversityClubsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            try
            {
           
                return ExecuteNonQuery("BGA_UpdateCVUniversityClubsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateCVUniversityClubsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {

                return ExecuteNonQuery(tran,"BGA_UpdateCVUniversityClubsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Add Functions
				public static object Add(int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };
				
				
				return ExecuteScalarObj("BGA_AddCVUniversityClubs", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static object Add(SqlTransaction tran,int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };
				
				
				return ExecuteScalarObj(tran,"BGA_AddCVUniversityClubs", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Delete Functions
		public static int Delete(int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
			
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery("BGA_DeleteCVUniversityClubs", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}

		public static int Delete(SqlTransaction tran,int cVId, int universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
			
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

                return ExecuteNonQuery(tran,"BGA_DeleteCVUniversityClubs", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(SqlTransaction tran,int? cVId, int? universityClub)
		{
			SqlParameter[] sqlParams = null;

            try
            {
  	            sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@UniversityClub",universityClub)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteCVUniversityClubsByParams", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteCVUniversityClubsByParams", sqlParams);

                
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVUniversityClubsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(int? cVId, int? universityClub)
		{
			return DeleteByParams(null,cVId, universityClub)
;
		}
		
		

		#endregion

		}
	}
}
