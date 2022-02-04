using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BalajiVedic.DAL
{
   public class PoojaSponsor
    {

        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;


        #region Donor List Reports

        public DataTable GetReportsPoojaSponsorListByVariable(Int64 iPoojaId, string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iPoojaId",iPoojaId),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };


                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReportsPoojaSponsorGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable ExportToReportsPoojaSponsorList(Int64 iPoojaId, string StartDate, string EndDate, string Search, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {


                    new SqlParameter("@iPoojaId",iPoojaId),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };
                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToReportsPoojaSponsorList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
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
