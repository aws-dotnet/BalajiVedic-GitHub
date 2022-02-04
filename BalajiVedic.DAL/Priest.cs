using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
  public  class Priest
    {
        #region Priest 
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 PriestInsert(Entities.Priest objPriest)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iPriestId",objPriest.iPriestId),
                    new SqlParameter("@sPriestName",(objPriest.sPriestName==null?(object)DBNull.Value:objPriest.sPriestName)),
                    new SqlParameter("@bActive",objPriest.bActive),
                    new SqlParameter("@sCreateUser",objPriest.sCreateUser),
                    new SqlParameter("@dCreateDate",DateTime.Now),
                    new SqlParameter("@sUpdateUser",objPriest.sUpdateUser),
                    new SqlParameter("@dUpdateDate",DateTime.Now),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PriestInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetPriestListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("PriestGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetPriestList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PriestGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetPriestListById(Int64 iPriestId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iPriestId",iPriestId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PriestGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeletePriest(Int64 iPriestId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iPriestId",iPriestId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PriestDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 UpdatePriestStatus(Int64 iPriestId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iPriestId",iPriestId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PriestUpdateStatus", ref _sqlP);
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
