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

    public partial class CVCertificateInfoProvider : BaseDataLayer
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
                        ds = ExecuteDataset("BGA_GetCVCertificateInfo", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVCertificateInfo", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Get", ArrangeParamValues(sqlParams));
                }
            }

            public static DataSet GetByParams(int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return GetByParams(null, id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
    ;
            }

            public static DataSet GetByParams(SqlTransaction tran, int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    DataSet ds = null;

                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@BeforeCertificateDate",beforeCertificateDate),
					new SqlParameter("@AfterOrEqualCertificateDate",afterOrEqualCertificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    if (tran == null)
                        ds = ExecuteDataset("BGA_GetCVCertificateInfoByParams", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVCertificateInfoByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
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

                    ds = ExecuteDataset("BGA_GetCVCertificateInfoByParams", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "GetByParams", ArrangeParamValues(sqlParams));
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
                        ds = ExecuteDataset("BGA_GetCVCertificateInfoByFK", sqlParams);
                    else
                        ds = ExecuteDataset(tran, "BGA_GetCVCertificateInfoByFK", sqlParams);

                    return ds;
                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "GetByFK", ArrangeParamValues(sqlParams));
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
            public static int Update(int id, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery("BGA_UpdateCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int Update(SqlTransaction tran, int id, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Update", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(int id, int? cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery("BGA_UpdateCVCertificateInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery("BGA_UpdateCVCertificateInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, int id, int? cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteNonQuery(tran, "BGA_UpdateCVCertificateInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int UpdateByParams(SqlTransaction tran, params SqlParameter[] sqlParams)
            {
                try
                {

                    return ExecuteNonQuery(tran, "BGA_UpdateCVCertificateInfoByParams", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "UpdateByParams", ArrangeParamValues(sqlParams));
                }
            }
            #endregion

            #region Add Functions
            public static int Add(int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteScalar("BGA_AddCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Add", ArrangeParamValues(sqlParams));
                }
            }

            public static int Add(SqlTransaction tran, int cVId, DateTime? certificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    return ExecuteScalar(tran, "BGA_AddCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Add", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery("BGA_DeleteCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Delete", ArrangeParamValues(sqlParams));
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

                    return ExecuteNonQuery(tran, "BGA_DeleteCVCertificateInfo", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "Delete", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(SqlTransaction tran, int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                SqlParameter[] sqlParams = null;

                try
                {
                    sqlParams = new SqlParameter[] { 
					new SqlParameter("@ID",id),
					new SqlParameter("@CVId",cVId),
					new SqlParameter("@CertificateDate",certificateDate),
					new SqlParameter("@BeforeCertificateDate",beforeCertificateDate),
					new SqlParameter("@AfterOrEqualCertificateDate",afterOrEqualCertificateDate),
					new SqlParameter("@Category",category),
					new SqlParameter("@Name",name),
					new SqlParameter("@TakenInstitution",takenInstitution),
					new SqlParameter("@Description",description)
                };

                    if (tran == null)
                        return ExecuteNonQuery("BGA_DeleteCVCertificateInfoByParams", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVCertificateInfoByParams", sqlParams);


                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "DeleteByParams", ArrangeParamValues(sqlParams));
                }
            }

            public static int DeleteByParams(int? id, int? cVId, DateTime? certificateDate, DateTime? beforeCertificateDate, DateTime? afterOrEqualCertificateDate, int? category, string name, string takenInstitution, string description)
            {
                return DeleteByParams(null, id, cVId, certificateDate, beforeCertificateDate, afterOrEqualCertificateDate, category, name, takenInstitution, description)
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
                        return ExecuteNonQuery("BGA_DeleteCVCertificateInfoByFK", sqlParams);
                    else
                        return ExecuteNonQuery(tran, "BGA_DeleteCVCertificateInfoByFK", sqlParams);

                }
                catch (Exception ex)
                {
                    throw new MyException(ex.Message, "CVCertificateInfoProvider", "DeleteByFK", ArrangeParamValues(sqlParams));
                }
            }


            #endregion

        }
    }
}
