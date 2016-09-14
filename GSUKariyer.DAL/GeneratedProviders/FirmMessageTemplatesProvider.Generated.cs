using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class FirmMessageTemplatesProvider:BaseDataLayer {
		
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
                	ds = ExecuteDataset("BGA_GetFirmMessageTemplates", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetFirmMessageTemplates", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Get", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(int? id, int? firmId, string content)
		{
			return GetByParams(null,id, firmId, content)
;
		}
		
		public static DataSet GetByParams(SqlTransaction tran,int? id, int? firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetFirmMessageTemplatesByParams", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetFirmMessageTemplatesByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                ds = ExecuteDataset("BGA_GetFirmMessageTemplatesByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
		public static int Update(int id, int firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

                return ExecuteNonQuery("BGA_UpdateFirmMessageTemplates", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Update(SqlTransaction tran,int id, int firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateFirmMessageTemplates", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(int id, int? firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

                return ExecuteNonQuery("BGA_UpdateFirmMessageTemplatesByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            try
            {
           
                return ExecuteNonQuery("BGA_UpdateFirmMessageTemplatesByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,int id, int? firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateFirmMessageTemplatesByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {

                return ExecuteNonQuery(tran,"BGA_UpdateFirmMessageTemplatesByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Add Functions
				public static int Add(int firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };
				
								return ExecuteScalar("BGA_AddFirmMessageTemplates", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Add(SqlTransaction tran,int firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };
				
				return ExecuteScalar(tran,"BGA_AddFirmMessageTemplates", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Add", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery("BGA_DeleteFirmMessageTemplates", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Delete", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery(tran,"BGA_DeleteFirmMessageTemplates", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(SqlTransaction tran,int? id, int? firmId, string content)
		{
			SqlParameter[] sqlParams = null;

            try
            {
  	            sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@FirmId",firmId),
					new SqlParameter("@Content",content)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteFirmMessageTemplatesByParams", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteFirmMessageTemplatesByParams", sqlParams);

                
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "FirmMessageTemplatesProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(int? id, int? firmId, string content)
		{
			return DeleteByParams(null,id, firmId, content)
;
		}
		
		

		#endregion

		}
	}
}
