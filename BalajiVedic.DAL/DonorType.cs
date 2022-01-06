using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BalajiVedic.DAL
{

  public class DonorType
    {
        #region DonorType 
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 InsertDonorType(Entities.DonorType objDonorType)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iDonorTypeID",objDonorType.iDonorTypeID),
                    new SqlParameter("@sDonorType",(objDonorType.sDonorType==null?(object)DBNull.Value:objDonorType.sDonorType)),
                    new SqlParameter("@bActive",objDonorType.bActive),
                    new SqlParameter("@sCreateUser",objDonorType.sCreateUser),
                    new SqlParameter("@dCreateDate",DateTime.Now),
                    new SqlParameter("@sLastUpdateUser",objDonorType.sLastUpdateUser),
                    new SqlParameter("@dLastUpdateDate",DateTime.Now),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonorTypeInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetDonorTypeListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {

                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorTypeGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetDonorTypeList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorTypeGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetDonorTypeListById(Int64 iDonorTypeID, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorTypeSelect", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteDonorType(Int64 iDonorTypeID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonorTypeDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 UpdateDonorTypeStatus(Int64 iDonorTypeID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonorTypeUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }



        #endregion

    }
}
