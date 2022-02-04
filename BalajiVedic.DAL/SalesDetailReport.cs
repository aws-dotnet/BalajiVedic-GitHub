using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
 public   class SalesDetailReport
    {

        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;


        #region Reports Sales Services


 

        //public DataTable ReportsSalesServicesGetList(string StartDate, string EndDate, ref int status)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        _sqlP = new[]
        //        {

        //              new SqlParameter("@StartDate",StartDate),
        //            new SqlParameter("@EndDate",EndDate),
        //            new SqlParameter("@QStatus",0)
        //        };


        //        _sqlP[2].Direction = System.Data.ParameterDirection.Output;
        //        dt = _dbAccess.GetDataTable("ReportsSalesServicesGetList", ref _sqlP);
        //        status = Convert.ToInt32(_sqlP[2].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}

        public DataSet ReportsSalesServicesGetList(string StartDate, string EndDate, ref int status)
        {
            DataSet dt = null;
            try
            {
                _sqlP = new[]
                {
                   new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataSet("ReportsSalesServicesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable ExportToReportsSalesServices(string StartDate, string EndDate, ref int status)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {



                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToReportsSalesServices", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        #endregion


        #region Sales Summary


        //public DataSet SalesSummaryReportGetList(string StartDate,string EndDate, ref int status)
        //{
        //    DataSet dt = null;
        //    try
        //    {
        //        _sqlP = new[]
        //        {
        //            new SqlParameter("@StartDate",StartDate),
        //            new SqlParameter("@EndDate",EndDate),
        //            new SqlParameter("@QStatus",0)
        //        };
        //        _sqlP[2].Direction = System.Data.ParameterDirection.Output;
        //        dt = _dbAccess.GetDataSet("SalesSummaryReportGetList", ref _sqlP);
        //        status = Convert.ToInt32(_sqlP[2].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}


        public DataSet SalesSummaryReportGetList(string StartDate, string EndDate, ref int status)
        {
            DataSet dt = null;
            try
            {
                _sqlP = new[]
                {
                   new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataSet("SalesSummaryReportGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportToSalesSummaryReport(string StartDate, string EndDate, ref int status)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {



                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToSalesSummaryReport", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        #endregion


        #region SalesDetailReport

        public DataTable GetReportsReportsSalesDetailByVariable(string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("ReportsSalesDetailGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable ExportToReportsSalesDetail(string StartDate, string EndDate, string Search, string Sort)
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
                dt = _dbAccess.GetDataTable("ExportToReportsSalesDetail", ref _sqlP);
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
