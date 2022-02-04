using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
  public  class Donors
    {
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;


        #region Donros
        public Int64 DonorsInsert(Entities.Donors objDonors,ref Int64 iDonorID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iDonorID",objDonors.iDonorID),
                    new SqlParameter("@sLastName",(objDonors.sLastName==null?(object)DBNull.Value:objDonors.sLastName)),
                    new SqlParameter("@sFirstName",(objDonors.sFirstName==null?(object)DBNull.Value:objDonors.sFirstName)),
                    new SqlParameter("@sSpouseName",(objDonors.sSpouseName==null?(object)DBNull.Value:objDonors.sSpouseName)),
                    new SqlParameter("@sChildrenInfo",(objDonors.sChildrenInfo==null?(object)DBNull.Value:objDonors.sChildrenInfo)),
                    new SqlParameter("@sStreetName",(objDonors.sStreetName==null?(object)DBNull.Value:objDonors.sStreetName)),
                    new SqlParameter("@sCity",(objDonors.sCity==null?(object)DBNull.Value:objDonors.sCity)),
                    new SqlParameter("@sState",(objDonors.sState==null?(object)DBNull.Value:objDonors.sState)),
                    new SqlParameter("@sZipCode",(objDonors.sZipCode==null?(object)DBNull.Value:objDonors.sZipCode)),
                    new SqlParameter("@sHomePhone",(objDonors.sHomePhone==null?(object)DBNull.Value:objDonors.sHomePhone)),
                    new SqlParameter("@sCellPhone",(objDonors.sCellPhone==null?(object)DBNull.Value:objDonors.sCellPhone)),
                    new SqlParameter("@sEmail",(objDonors.sEmail==null?(object)DBNull.Value:objDonors.sEmail)),
                    new SqlParameter("@sGothram",(objDonors.sGothram==null?(object)DBNull.Value:objDonors.sGothram)),
                    new SqlParameter("@sBirthStar",(objDonors.sBirthStar==null?(object)DBNull.Value:objDonors.sBirthStar)),
                    new SqlParameter("@dDateOfArchana", (objDonors.dDateOfArchana == DateTime.MinValue) ? Convert.DBNull : objDonors.dDateOfArchana),
                    new SqlParameter("@sDayOfArchana",(objDonors.sDayOfArchana==null?(object)DBNull.Value:objDonors.sDayOfArchana)),
                    new SqlParameter("@iDonorTypeID",(objDonors.iDonorTypeID == 0 ?DBNull.Value:(object)objDonors.iDonorTypeID)),
                    new SqlParameter("@dDateOfJoin", (objDonors.dDateOfJoin == DateTime.MinValue) ? Convert.DBNull : objDonors.dDateOfJoin),
                    new SqlParameter("@bActive",objDonors.bActive),
                    new SqlParameter("@dCreateDate",DateTime.Now),
                    new SqlParameter("@sCreateUser",objDonors.sCreateUser),
                    new SqlParameter("@dLastUpdateUser",objDonors.dLastUpdateUser),
                    new SqlParameter("@dLastUpdateDate",DateTime.Now),
                    new SqlParameter("@sZodiac",(objDonors.sZodiac==null?(object)DBNull.Value:objDonors.sZodiac)),
                    new SqlParameter("@sSpouseLastName",(objDonors.sSpouseLName==null?(object)DBNull.Value:objDonors.sSpouseLName)),
                    new SqlParameter("@sCountry",(objDonors.sCountry==null?(object)DBNull.Value:objDonors.sCountry)),
                    new SqlParameter("@QStatus",0)


                  };
                _sqlP[0].Direction = _sqlP[26].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DonorsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[26].Value);

                iDonorID = Convert.ToInt64(_sqlP[0].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetStateList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("StateGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetDonorsListByVariable(string sLastName, string sFirstName, string dDateOfJoin,Int64 iDonorTypeID,Int64 iDonorId,string sPhoneNumber,string sSpouseLastName, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@sLastName",sLastName),
                    new SqlParameter("@sFirstName",sFirstName),
                    new SqlParameter("@dDateOfJoin",dDateOfJoin),
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@iDonorId",iDonorId),
                    new SqlParameter("@sPhoneNumber",sPhoneNumber),
                    new SqlParameter("@sSpouseLastName",sSpouseLastName),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[11].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[11].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetDonorDonationsListByVariable(Int64 iDonorId,Int64 iYear ,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    
                    new SqlParameter("@iDonorId",iDonorId),
                    new SqlParameter("@iYear",iYear),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[6].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorDonationsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetDonationTypeListById(Int64 iDonorId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonorId",iDonorId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("DonorsGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        #endregion


        #region Donor List Reports

        public DataTable GetReportsDonorListByVariable(Int64 iDonorTypeID,string StartDate,string EndDate,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };


                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReportsDonorListGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable ExportToReportsDonorList(Int64 iDonorTypeID, string StartDate, string EndDate, string Search, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {
                       
                    
                    new SqlParameter("@iDonorTypeID",iDonorTypeID),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };
                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToReportsDonorList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        #endregion


        #region Donor List By Donation Report

        public DataTable GetReportsDonorListByDonationListByVariable(string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                  
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };


                _sqlP[6].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReportsDonorListByDonationGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportToReportsDonorListByDonationList(string StartDate, string EndDate, string Search, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {


                  
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };
                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToReportsDonorListByDonationList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable ExportToDonorDonationsByList(Int64 iDonorId, Int64 iYear, string Search, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {



                    new SqlParameter("@iDonorId",iDonorId),
                    new SqlParameter("@iYear",iYear),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };
                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToDonorDonationsList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        #endregion
    }
}
