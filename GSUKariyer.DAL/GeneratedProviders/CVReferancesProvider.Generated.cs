using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using GSUKariyer.COMMON.Helpers.DAL;
using GSUKariyer.COMMON.Exceptions;

namespace GSUKariyer.DAL
{

    public partial class CVReferancesProvider : BaseDataLayer
    {

        public class Generated
        {

            #region Get Functions
            protected static DataSet GetBasic(SqlTransaction tran, int? id)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVReferances", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVReferances", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return GetByParams(null, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVReferancesByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVReferancesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(params SqlParameter[] sqlParams)
            {
                return GetByParams(null, sqlParams);
            }

            public static DataSet GetByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {
                    DataSet ds = null;

                    ds = ExecuteDataset("BGA_GetCVReferancesByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "GetByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByFKBasic(int? cVId)
            {
                return GetByFKBasic(null, cVId);
            }

            public static DataSet GetByFKBasic(SqlTransaction tran, int? cVId)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVReferancesByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVReferancesByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "GetByFK", ArrangeParamValues(sqlParams));
                }
            }


            public static DataSet GetAll(SqlTransaction tran)
            {
                return GetBasic(tran, null);
            }

            public static DataSet GetAll()
            {
                return GetBasic(null, null);
            }

            public static DataSet Get(SqlTransaction tran, int id)
            {
                return GetBasic(tran, id);
            }

            public static DataSet Get(int id)
            {
                return GetBasic(null, id);
            }

            public static DataSet GetByFK(SqlTransaction tran, int cVId)
            {
                return GetByFKBasic(tran, cVId);
            }

            public static DataSet GetByFK(int cVId)
            {
                return GetByFKBasic(cVId);
            }


            #endregion

            #region Update Functions
            public static int Update(int id, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteNonQuery("BGA_UpdateCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteNonQuery("BGA_UpdateCVReferancesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVReferancesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVReferancesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVReferancesByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteScalar("BGA_AddCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    return ExecuteScalar(tran, "BGA_AddCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int Delete(SqlTransaction tran, int id)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id)
                };

                    return ExecuteNonQuery(tran, "BGA_DeleteCVReferances", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@Name",name),
					new SqlParameter("@Surname",surname),
					new SqlParameter("@Email",email),
					new SqlParameter("@Phone",phone),
					new SqlParameter("@WorkingFirm",workingFirm),
					new SqlParameter("@FirmSector",firmSector),
					new SqlParameter("@WorkingPosition",workingPosition)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVReferancesByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVReferancesByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? cVId, string name, string surname, string email, string phone, string workingFirm, string firmSector, string workingPosition)
            {
                return DeleteByParams(null, id, cVId, name, surname, email, phone, workingFirm, firmSector, workingPosition)
    ;
            }

            public static int DeleteByFK(int? cVId)
            {
                return DeleteByFK(null, cVId)
    ;
            }

            public static int DeleteByFK(SqlTransaction tran, int? cVId)
            {
                SqlParameter[] sqlParams = null;

                try
                {

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVReferancesByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVReferancesByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVReferancesProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
