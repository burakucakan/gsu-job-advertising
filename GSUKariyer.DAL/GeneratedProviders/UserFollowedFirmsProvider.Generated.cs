using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class UserFollowedFirmsProvider:BaseDataLayer {
		
		public class Generated{
		
		#region Get Functions
		protected static DataSet GetBasic(SqlTransaction tran,int? id)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetUserFollowedFirms", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetUserFollowedFirms", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Get", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(int? id, int? userId, int? firmId)
		{
			return GetByParams(null,id, userId, firmId)
;
		}
		
		public static DataSet GetByParams(SqlTransaction tran,int? id, int? userId, int? firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetUserFollowedFirmsByParams", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetUserFollowedFirmsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                ds = ExecuteDataset("BGA_GetUserFollowedFirmsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "GetByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
				
		
		public static DataSet GetAll(SqlTransaction tran)
		{
			return GetBasic(tran,null);
		}
		
		public static DataSet GetAll()
		{
			return GetBasic(null,null);
		}
		
		public static DataSet Get(SqlTransaction tran,int id)
		{
			return GetBasic(tran,id);
		}
		
		public static DataSet Get(int id)
		{
			return GetBasic(null,id);
		}
		
		
			
		#endregion
	
		#region Update Functions
		public static int Update(int id, int userId, int firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

                return ExecuteNonQuery("BGA_UpdateUserFollowedFirms", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Update(SqlTransaction tran,int id, int userId, int firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateUserFollowedFirms", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(int id, int? userId, int? firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

                return ExecuteNonQuery("BGA_UpdateUserFollowedFirmsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            try
            {
           
                return ExecuteNonQuery("BGA_UpdateUserFollowedFirmsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,int id, int? userId, int? firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateUserFollowedFirmsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {

                return ExecuteNonQuery(tran,"BGA_UpdateUserFollowedFirmsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Add Functions
				public static int Add(int id, int userId, int firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };
				
								return ExecuteScalar("BGA_AddUserFollowedFirms", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Add(SqlTransaction tran,int id, int userId, int firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };
				
				return ExecuteScalar(tran,"BGA_AddUserFollowedFirms", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Delete Functions
		public static int Delete(int id)
		{
			SqlParameter[] sqlParams = null;

            try
            {
			
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                return ExecuteNonQuery("BGA_DeleteUserFollowedFirms", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}

		public static int Delete(SqlTransaction tran,int id)
		{
			SqlParameter[] sqlParams = null;

            try
            {
			
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                return ExecuteNonQuery(tran,"BGA_DeleteUserFollowedFirms", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(SqlTransaction tran,int? id, int? userId, int? firmId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
  	            sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@UserId",userId),
					new SqlParameter("@FirmId",firmId)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteUserFollowedFirmsByParams", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteUserFollowedFirmsByParams", sqlParams);

                
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "UserFollowedFirmsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(int? id, int? userId, int? firmId)
		{
			return DeleteByParams(null,id, userId, firmId)
;
		}
		
		

		#endregion

		}
	}
}
