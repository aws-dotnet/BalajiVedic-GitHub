using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
 public   class DonationType
    {
        #region DonationType 
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 InsertDonationType(Entities.DonationType objDonationType)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iDonationTypeID",objDonationType.iDonationTypeID),
                    new SqlParameter("@sDonationTypeDesc",(objDonationType.sDonationTypeDesc==null?(object)DBNull.Value:objDonationType.sDonationTypeDesc)),
                    new SqlParameter("@fPrice",(objDonationType.fPrice==double.MinValue?(object)DBNull.Value:objDonationType.fPrice)),
                    new SqlParameter("@sDonationType",(objDonationType.sDonationType==null?(object)DBNull.Value:objDonationType.sDonationType)),
                    new SqlParameter("@bActive",objDonationType.bActive),
                    new SqlParameter("@bTaxDeductible",(objDonationType.bTaxDeductible == false ?DBNull.Value:(object)objDonationType.bTaxDeductible)),
                    new SqlParameter("@sCreateUser",objDonationType.sCreateUser),
                    new SqlParameter("@dCreateUser",DateTime.Now),
                    new SqlParameter("@sLastUpdateUser",objDonationType.sLastUpdateUser),
                    new SqlParameter("@dLastUpdateDate",DateTime.Now),
                    new SqlParameter("@sPoojaFrequency",(objDonationType.sPoojaFrequency==null?(object)DBNull.Value:objDonationType.sPoojaFrequency)),
                    new SqlParameter("@sNotes",(objDonationType.sNotes==null?(object)DBNull.Value:objDonationType.sNotes)),
                    new SqlParameter("@fPriestCommision",(objDonationType.fPriestCommision==double.MinValue?(object)DBNull.Value:objDonationType.fPriestCommision)),
                    new SqlParameter("@sPriestCommissionBased",(objDonationType.sPriestCommissionBased==null?(object)DBNull.Value:objDonationType.sPriestCommissionBased)),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[14].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonationTypeInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[14].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetDonationTypeListByVariable(string ddlType, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@ddlType",ddlType),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonationTypeGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetPoojaDonationsListByVariable(string sFrequency, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@sFrequency",sFrequency),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PoojaDonationsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DonationTypeNotesUpdate(Entities.DonationType objDonationType)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iDonationTypeID",objDonationType.iDonationTypeID),
                    new SqlParameter("@sNotes",(objDonationType.sNotes==null?(object)DBNull.Value:objDonationType.sNotes)),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonationTypeNotesUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }



        public DataTable GetDonationTypeList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonationTypeGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetDonationTypeListById(Int64 iDonationTypeID, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonationTypeID",iDonationTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonationTypeGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DonationTypeDelete(Int64 iDonationTypeID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonationTypeID",iDonationTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonationTypeDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 UpdateDonationTypeStatus(Int64 iDonationTypeID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonationTypeID",iDonationTypeID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonationTypeUpdateStatus", ref _sqlP);
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
