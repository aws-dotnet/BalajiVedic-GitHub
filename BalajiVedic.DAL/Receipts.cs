using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
 public   class Receipts
    {
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetReceiptsListByVariable(string sLastName,string dReceiptDate,Int64 iReceiptId,Int64 iDonorId, Int64 iYear, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {

                    new SqlParameter("@sLastName",sLastName),
                    new SqlParameter("@dReceiptDate",dReceiptDate),
                    new SqlParameter("@iReceiptId",iReceiptId),
                    new SqlParameter("@iDonorId",iDonorId),
                    new SqlParameter("@iYear",iYear),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[9].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReceiptsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[9].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public Int64 ReceiptsInsert(Entities.Receipts objReceipts)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                   
                    new SqlParameter("@iReceiptID",objReceipts.iReceiptId),
                    new SqlParameter("@dReceiptDate", (objReceipts.dReceiptDate == DateTime.MinValue) ? Convert.DBNull : objReceipts.dReceiptDate),
                    new SqlParameter("@iDonorID",(objReceipts.iDonorID == 0 ?DBNull.Value:(object)objReceipts.iDonorID)),
                    new SqlParameter("@iDonorTypeID",(objReceipts.iDonorTypeID == 0 ?DBNull.Value:(object)objReceipts.iDonorTypeID)),
                    new SqlParameter("@fAmount",(objReceipts.fAmount==decimal.MinValue?(object)DBNull.Value:objReceipts.fAmount)),
                    new SqlParameter("@dDateOfSponsorship", (objReceipts.dDateOfSponsorship == DateTime.MinValue) ? Convert.DBNull : objReceipts.dDateOfSponsorship),
                    new SqlParameter("@iPaymentMethodID",(objReceipts.iPaymentMethodID == 0 ?DBNull.Value:(object)objReceipts.iPaymentMethodID)),
                    new SqlParameter("@sPaymentInfo",(objReceipts.sPaymentInfo==null?(object)DBNull.Value:objReceipts.sPaymentInfo)),
                    new SqlParameter("@sCreateUser",(objReceipts.sCreateUser==null?(object)DBNull.Value:objReceipts.sCreateUser)),
                    new SqlParameter("@dCreateDate", (objReceipts.dCreateDate == DateTime.MinValue) ? Convert.DBNull : objReceipts.dCreateDate),
                    new SqlParameter("@sComments",(objReceipts.sComments==null?(object)DBNull.Value:objReceipts.sComments)),
                    new SqlParameter("@sCompanyName",(objReceipts.sCompanyName==null?(object)DBNull.Value:objReceipts.sCompanyName)),
                    new SqlParameter("@sApprovalCode",(objReceipts.sApprovalCode==null?(object)DBNull.Value:objReceipts.sApprovalCode)),
                    new SqlParameter("@sRawResponse",(objReceipts.sRawResponse==null?(object)DBNull.Value:objReceipts.sRawResponse)),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[14].Direction = _sqlP[26].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ReceiptsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[14].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable ReceiptsGetById(Int64 iReceiptId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iReceiptId",iReceiptId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReceiptsGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetReceiptViewListByVariable(Int64 iReceiptId,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {

                    new SqlParameter("@iReceiptId",iReceiptId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ReceiptViewGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }
}
