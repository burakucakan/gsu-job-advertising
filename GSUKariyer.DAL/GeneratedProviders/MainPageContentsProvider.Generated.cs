using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class MainPageContentsProvider:BaseDataLayer {
		
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
                	ds = ExecuteDataset("BGA_GetMainPageContents", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetMainPageContents", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Get", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return GetByParams(null,id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
;
		}
		
		public static DataSet GetByParams(SqlTransaction tran,int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetMainPageContentsByParams", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetMainPageContentsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                ds = ExecuteDataset("BGA_GetMainPageContentsByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
		public static int Update(int id, int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                return ExecuteNonQuery("BGA_UpdateMainPageContents", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Update(SqlTransaction tran,int id, int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateMainPageContents", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(int id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? createDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                return ExecuteNonQuery("BGA_UpdateMainPageContentsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            try
            {
           
                return ExecuteNonQuery("BGA_UpdateMainPageContentsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,int id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? createDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateMainPageContentsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {

                return ExecuteNonQuery(tran,"BGA_UpdateMainPageContentsByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Add Functions
				public static int Add(int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate, DateTime createDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };
				
								return ExecuteScalar("BGA_AddMainPageContents", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Add(SqlTransaction tran,int mainPageRegion, int contentType, int contentId, int contentOrder, DateTime modifyDate, DateTime createDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@CreateDate",createDate)
                };
				
				return ExecuteScalar(tran,"BGA_AddMainPageContents", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Add", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery("BGA_DeleteMainPageContents", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Delete", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery(tran,"BGA_DeleteMainPageContents", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(SqlTransaction tran,int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			SqlParameter[] sqlParams = null;

            try
            {
  	            sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@MainPageRegion",mainPageRegion),
					new SqlParameter("@ContentType",contentType),
					new SqlParameter("@ContentId",contentId),
					new SqlParameter("@ContentOrder",contentOrder),
					new SqlParameter("@ModifyDate",modifyDate),
					new SqlParameter("@BeforeModifyDate",beforeModifyDate),
					new SqlParameter("@AfterOrEqualModifyDate",afterOrEqualModifyDate),
					new SqlParameter("@CreateDate",createDate),
					new SqlParameter("@BeforeCreateDate",beforeCreateDate),
					new SqlParameter("@AfterOrEqualCreateDate",afterOrEqualCreateDate)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteMainPageContentsByParams", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteMainPageContentsByParams", sqlParams);

                
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "MainPageContentsProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(int? id, int? mainPageRegion, int? contentType, int? contentId, int? contentOrder, DateTime? modifyDate, DateTime? beforeModifyDate, DateTime? afterOrEqualModifyDate, DateTime? createDate, DateTime? beforeCreateDate, DateTime? afterOrEqualCreateDate)
		{
			return DeleteByParams(null,id, mainPageRegion, contentType, contentId, contentOrder, modifyDate, beforeModifyDate, afterOrEqualModifyDate, createDate, beforeCreateDate, afterOrEqualCreateDate)
;
		}
		
		

		#endregion

		}
	}
}
