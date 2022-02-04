using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
  public  class Receipts
    {

        //kiran
        DAL.Receipts _Receipts = new DAL.Receipts();

        public Int64 ReceiptsInsert(Entities.Receipts objReceipts)
        {
            Int64 _status = 0;
            if (objReceipts != null)
            {
                _status = _Receipts.ReceiptsInsert(objReceipts);

            }
            return _status;
        }



        public List<Entities.Receipts> GetReceiptsListByVariable(string sLastName, string dReceiptDate, Int64 iReceiptId, Int64 iDonorId, Int64 iYear, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Receipts> lstDonors = new List<Entities.Receipts>();
            DataTable dt = _Receipts.GetReceiptsListByVariable(sLastName, dReceiptDate,iReceiptId, iDonorId, iYear, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Receipts objReceipts = new Entities.Receipts();

                    objReceipts.RId = Convert.ToInt32(dr["RId"].ToString());
                    objReceipts.ViewButton = (dr["ViewButton"] != DBNull.Value ? dr["ViewButton"].ToString() : "");
                    objReceipts.iReceiptId = (dr["iReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["iReceiptId"]) : 0);
                    objReceipts.dReceiptDate = (dr["dReceiptDate"] != DBNull.Value ? Convert.ToDateTime(dr["dReceiptDate"]) : DateTime.MinValue);
                    objReceipts.iDonorID = (dr["iDonorID"] != DBNull.Value ? Convert.ToInt64(dr["iDonorID"]) : 0);
                    objReceipts.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDecimal(dr["fAmount"]) : 0);
                    objReceipts.dDateOfSponsorship = (dr["dDateOfSponsorship"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfSponsorship"]) : DateTime.MinValue);
                    objReceipts.iPaymentMethodID = (dr["iPaymentMethodID"] != DBNull.Value ? Convert.ToInt64(dr["iPaymentMethodID"]) : 0);
                    objReceipts.sPaymentInfo = (dr["sPaymentInfo"] != DBNull.Value ? dr["sPaymentInfo"].ToString() : "");
                    objReceipts.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objReceipts.dCreateDate = (dr["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateDate"]) : DateTime.MinValue);
                    objReceipts.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objReceipts.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");
                    objReceipts.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objReceipts.sOtherText = (dr["sOtherText"] != DBNull.Value ? dr["sOtherText"].ToString() : "");
                    objReceipts.iVoidReceiptId = (dr["iVoidReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["iVoidReceiptId"]) : 0);
                    objReceipts.sVoidReason = (dr["sVoidReason"] != DBNull.Value ? dr["sVoidReason"].ToString() : "");
                    objReceipts.sVoidedUser = (dr["sVoidedUser"] != DBNull.Value ? dr["sVoidedUser"].ToString() : "");
                    objReceipts.bIsStoreVoid = (dr["bIsStoreVoid"] != DBNull.Value ? Convert.ToInt64(dr["bIsStoreVoid"]) : 0);

                  

                    lstDonors.Add(objReceipts);
                }
            }
            return lstDonors;
        }


        public Entities.Receipts ReceiptsGetById(Int64 iReceiptId, ref int status)
        {
            Entities.Receipts objReceipts = new Entities.Receipts();
            DataTable dt = new DataTable();
            if (iReceiptId != 0)
            {
                dt = _Receipts.ReceiptsGetById(iReceiptId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objReceipts.iReceiptId = (dt.Rows[0]["iReceiptId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iReceiptId"]) : 0);
                    objReceipts.dReceiptDate = (dt.Rows[0]["dReceiptDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dReceiptDate"]) : DateTime.MinValue);
                    objReceipts.fAmount = (dt.Rows[0]["fAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["fAmount"]) : 0);
                    objReceipts.sPaymentInfo = (dt.Rows[0]["sPaymentInfo"] != DBNull.Value ? dt.Rows[0]["sPaymentInfo"].ToString() : "");
                    objReceipts.sName = (dt.Rows[0]["sName"] != DBNull.Value ? dt.Rows[0]["sName"].ToString() : "");
                    objReceipts.sPaymentMethod = (dt.Rows[0]["sPaymentMethod"] != DBNull.Value ? dt.Rows[0]["sPaymentMethod"].ToString() : "");
                    objReceipts.sOtherText = (dt.Rows[0]["sOtherText"] != DBNull.Value ? dt.Rows[0]["sOtherText"].ToString() : "");
                    objReceipts.sVoidReason = (dt.Rows[0]["sVoidReason"] != DBNull.Value ? dt.Rows[0]["sVoidReason"].ToString() : "");
                    objReceipts.ApprovalCode = (dt.Rows[0]["ApprovalCode"] != DBNull.Value ? dt.Rows[0]["ApprovalCode"].ToString() : "");
                    objReceipts.iDonorID = (dt.Rows[0]["iDonorID"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iDonorID"]) : 0);
                    objReceipts.sEmail = (dt.Rows[0]["sEmail"] != DBNull.Value ? dt.Rows[0]["sEmail"].ToString() : "");
                    objReceipts.sComments = (dt.Rows[0]["sComments"] != DBNull.Value ? dt.Rows[0]["sComments"].ToString() : "");
                   

                }
            }
            return objReceipts;
        }

        public List<Entities.Receipts> GetReceiptViewListByVariable(Int64 iReceiptId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Receipts> lstDonors = new List<Entities.Receipts>();
            DataTable dt = _Receipts.GetReceiptViewListByVariable( iReceiptId, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Receipts objReceipts = new Entities.Receipts();

                    objReceipts.RId = Convert.ToInt32(dr["RId"].ToString());
                    objReceipts.iReceiptId = (dr["iReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["iReceiptId"]) : 0);
                    objReceipts.iReceiptDetailId = (dr["iReceiptDetailId"] != DBNull.Value ? Convert.ToInt64(dr["iReceiptDetailId"]) : 0);
                    objReceipts.iDonationTypeID = (dr["iDonationTypeID"] != DBNull.Value ? Convert.ToInt64(dr["iDonationTypeID"]) : 0);
                    objReceipts.Pooja = (dr["Pooja"] != DBNull.Value ? dr["Pooja"].ToString() : "");
                    objReceipts.Price = (dr["Price"] != DBNull.Value ? Convert.ToDecimal(dr["Price"]) : 0);
                    objReceipts.dSponsorDate = (dr["dSponsorDate"] != DBNull.Value ? Convert.ToDateTime(dr["dSponsorDate"]) : DateTime.MinValue);
   
                    lstDonors.Add(objReceipts);
                }
            }
            return lstDonors;
        }

    }
}
