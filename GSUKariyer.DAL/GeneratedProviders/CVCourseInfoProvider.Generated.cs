using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL {

	public partial class CVCourseInfoProvider:BaseDataLayer {
		
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
                	ds = ExecuteDataset("BGA_GetCVCourseInfo", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetCVCourseInfo", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Get", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static DataSet GetByParams(int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return GetByParams(null,id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
;
		}
		
		public static DataSet GetByParams(SqlTransaction tran,int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

				if (tran==null)
                	ds = ExecuteDataset("BGA_GetCVCourseInfoByParams", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetCVCourseInfoByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                ds = ExecuteDataset("BGA_GetCVCourseInfoByParams", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
						public static DataSet GetByFKBasic(int? cVId)
		{
			return GetByFKBasic(null,cVId);
		}
		
public static DataSet GetByFKBasic(SqlTransaction tran,int? cVId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                DataSet ds = null;

                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };
				
				if(tran==null)
                	ds = ExecuteDataset("BGA_GetCVCourseInfoByFK", sqlParams);
				else
					ds = ExecuteDataset(tran,"BGA_GetCVCourseInfoByFK", sqlParams);

                return ds;
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "GetByFK", ArrangeParamValues(sqlParams));
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
		
				public static DataSet GetByFK(SqlTransaction tran,int cVId)
		{
			return GetByFKBasic(tran,cVId);
		}
		
public static DataSet GetByFK(int cVId)
		{
			return GetByFKBasic(cVId);
		}
		
			
		#endregion
	
		#region Update Functions
		public static int Update(int id, int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

                return ExecuteNonQuery("BGA_UpdateCVCourseInfo", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Update(SqlTransaction tran,int id, int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateCVCourseInfo", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Update", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(int id, int? cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

                return ExecuteNonQuery("BGA_UpdateCVCourseInfoByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(params SqlParameter[] sqlParams)
		{
            try
            {
           
                return ExecuteNonQuery("BGA_UpdateCVCourseInfoByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,int id, int? cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

                return ExecuteNonQuery(tran,"BGA_UpdateCVCourseInfoByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int UpdateByParams(SqlTransaction tran,params SqlParameter[] sqlParams)
		{
            try
            {

                return ExecuteNonQuery(tran,"BGA_UpdateCVCourseInfoByParams", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
            }		
		}
		#endregion
	
		#region Add Functions
				public static int Add(int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };
				
								return ExecuteScalar("BGA_AddCVCourseInfo", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Add", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int Add(SqlTransaction tran,int cVId, string name, string institution, DateTime? startDate, DateTime? endDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };
				
				return ExecuteScalar(tran,"BGA_AddCVCourseInfo", sqlParams);
				
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Add", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery("BGA_DeleteCVCourseInfo", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Delete", ArrangeParamValues(sqlParams));
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

                return ExecuteNonQuery(tran,"BGA_DeleteCVCourseInfo", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "Delete", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(SqlTransaction tran,int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			SqlParameter[] sqlParams = null;

            try
            {
  	            sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Institution",institution),
					new SqlParameter("@StartDate",startDate),
					new SqlParameter("@BeforeStartDate",beforeStartDate),
					new SqlParameter("@AfterOrEqualStartDate",afterOrEqualStartDate),
					new SqlParameter("@EndDate",endDate),
					new SqlParameter("@BeforeEndDate",beforeEndDate),
					new SqlParameter("@AfterOrEqualEndDate",afterOrEqualEndDate),
					new SqlParameter("@DurationInHours",durationInHours),
					new SqlParameter("@Description",description)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteCVCourseInfoByParams", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteCVCourseInfoByParams", sqlParams);

                
            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
            }		
		}
		
		public static int DeleteByParams(int? id, int? cVId, string name, string institution, DateTime? startDate, DateTime? beforeStartDate, DateTime? afterOrEqualStartDate, DateTime? endDate, DateTime? beforeEndDate, DateTime? afterOrEqualEndDate, int? durationInHours, string description)
		{
			return DeleteByParams(null,id, cVId, name, institution, startDate, beforeStartDate, afterOrEqualStartDate, endDate, beforeEndDate, afterOrEqualEndDate, durationInHours, description)
;
		}
		
				public static int DeleteByFK(int? cVId)
		{
			return DeleteByFK(null,cVId)
;
		}
		
		public static int DeleteByFK(SqlTransaction tran,int? cVId)
		{
			SqlParameter[] sqlParams = null;

            try
            {
			
                sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };

				if (tran==null)
                	return ExecuteNonQuery("BGA_DeleteCVCourseInfoByFK", sqlParams);
				else
					return ExecuteNonQuery(tran,"BGA_DeleteCVCourseInfoByFK", sqlParams);

            }
            catch (Exception ex)
            {
                throw new MyException(ex.Message, "CVCourseInfoProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
            }		
		}
		

		#endregion

		}
	}
}
