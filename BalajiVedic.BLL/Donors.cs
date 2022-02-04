using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BalajiVedic.BLL
{
 public   class Donors
    {
        //kiran
        DAL.Donors _Donors = new DAL.Donors();


        #region Donors

        public Int64 DonorsInsert(Entities.Donors objDonors,ref Int64 iDonorID)
        {
            Int64 _status = 0;
            if (objDonors != null)
            {
                _status = _Donors.DonorsInsert(objDonors,ref iDonorID);

            }
            return _status;
        }

        public List<Entities.State> GetStateList(ref int status)
        {
            List<Entities.State> lstStates = new List<Entities.State>();
            DataTable dt = _Donors.GetStateList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.State objState = new Entities.State();

                    objState.sStateCode = (dr["sStateCode"] != DBNull.Value ? dr["sStateCode"].ToString() : "");
                    objState.sState = (dr["sState"] != DBNull.Value ? dr["sState"].ToString() : "");

                    lstStates.Add(objState);
                }

            }
            return lstStates;
        }


        public List<Entities.Donors> GetDonorsListByVariable(string sLastName, string sFirstName, string dDateOfJoin, Int64 iDonorTypeID, Int64 iDonorId, string sPhoneNumber, string sSpouseLastName, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            DataTable dt = _Donors.GetDonorsListByVariable(sLastName,sFirstName, dDateOfJoin, iDonorTypeID, iDonorId, sPhoneNumber,sSpouseLastName,Search,Sort,PageNo,Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Donors objlstDonors = new Entities.Donors();

                    objlstDonors.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonors.ViewButton = (dr["ViewButton"] != DBNull.Value ? dr["ViewButton"].ToString() : "");
                    objlstDonors.iDonorID = (dr["iDonorId"] != DBNull.Value ? Convert.ToInt64(dr["iDonorId"]) : 0);
                    objlstDonors.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");
                    objlstDonors.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objlstDonors.sSpouseName = (dr["sSpouseName"] != DBNull.Value ? dr["sSpouseName"].ToString() : "");
                    objlstDonors.sChildrenInfo = (dr["sChildrenInfo"] != DBNull.Value ? dr["sChildrenInfo"].ToString() : "");
                    objlstDonors.sStreetName = (dr["sStreetName"] != DBNull.Value ? dr["sStreetName"].ToString() : "");
                    objlstDonors.sCity = (dr["sCity"] != DBNull.Value ? dr["sCity"].ToString() : "");
                    objlstDonors.sStateCode = (dr["sStateCode"] != DBNull.Value ? dr["sStateCode"].ToString() : "");
                    objlstDonors.sZipCode = (dr["sZipCode"] != DBNull.Value ? dr["sZipCode"].ToString() : "");
                    objlstDonors.sHomePhone = (dr["sHomePhone"] != DBNull.Value ? dr["sHomePhone"].ToString() : "");
                    objlstDonors.sCellPhone = (dr["sCellPhone"] != DBNull.Value ? dr["sCellPhone"].ToString() : "");
                    objlstDonors.sEmail = (dr["sEmail"] != DBNull.Value ? dr["sEmail"].ToString() : "");
                    objlstDonors.sGothram = (dr["sGothram"] != DBNull.Value ? dr["sGothram"].ToString() : "");
                    objlstDonors.sBirthStar = (dr["sBirthStar"] != DBNull.Value ? dr["sBirthStar"].ToString() : "");
                    objlstDonors.dDateOfArchana = (dr["dDateOfArchana"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfArchana"]) : DateTime.MinValue);
                    objlstDonors.iDonorTypeID = (dr["iDonorTypeId"] != DBNull.Value ? Convert.ToInt64(dr["iDonorTypeId"]) : 0);
                    objlstDonors.sDonorType = (dr["sDonorType"] != DBNull.Value ? dr["sDonorType"].ToString() : "");
                    objlstDonors.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                    objlstDonors.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);
                    objlstDonors.sDayOfArchana = (dr["sDayOfArchana"] != DBNull.Value ? dr["sDayOfArchana"].ToString() : "");
                    objlstDonors.sZodiac = (dr["sZodiac"] != DBNull.Value ? dr["sZodiac"].ToString() : "");
                    objlstDonors.dDateOfJoin = (dr["dDateOfJoin"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfJoin"]) : DateTime.MinValue);
                   

                    lstDonors.Add(objlstDonors);
                }
            }
            return lstDonors;
        }



        public List<Entities.Donors> GetDonorDonationsListByVariable(Int64 iDonorId,Int64 iYear,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            DataTable dt = _Donors.GetDonorDonationsListByVariable(iDonorId,iYear,Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Donors objlstDonors = new Entities.Donors();

                    objlstDonors.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonors.ViewButton = (dr["ViewButton"] != DBNull.Value ? dr["ViewButton"].ToString() : "");
                    objlstDonors.iReceiptId = (dr["iReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["iReceiptId"]) : 0);
                    objlstDonors.dReceiptDate = (dr["dReceiptDate"] != DBNull.Value ? Convert.ToDateTime(dr["dReceiptDate"]) : DateTime.MinValue);
                    objlstDonors.iDonorID = (dr["iDonorID"] != DBNull.Value ? Convert.ToInt64(dr["iDonorID"]) : 0);
                    objlstDonors.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDecimal(dr["fAmount"]) : 0);
                    objlstDonors.dDateOfSponsorship = (dr["dDateOfSponsorship"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfSponsorship"]) : DateTime.MinValue);
                    objlstDonors.iPaymentMethodID = (dr["iPaymentMethodID"] != DBNull.Value ? Convert.ToInt64(dr["iPaymentMethodID"]) : 0);
                    objlstDonors.sPaymentInfo = (dr["sPaymentInfo"] != DBNull.Value ? dr["sPaymentInfo"].ToString() : "");
                    objlstDonors.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objlstDonors.dCreateDate = (dr["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateDate"]) : DateTime.MinValue);
                    objlstDonors.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objlstDonors.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");
                    objlstDonors.sDonationTypeDesc = (dr["sDonationTypeDesc"] != DBNull.Value ? dr["sDonationTypeDesc"].ToString() : "");
                    objlstDonors.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objlstDonors.sOtherText = (dr["sOtherText"] != DBNull.Value ? dr["sOtherText"].ToString() : "");
                    objlstDonors.iVoidReceiptId = (dr["iVoidReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["iVoidReceiptId"]) : 0);
                    objlstDonors.sVoidReason = (dr["sVoidReason"] != DBNull.Value ? dr["sVoidReason"].ToString() : "");
                    objlstDonors.sVoidedUser = (dr["sVoidedUser"] != DBNull.Value ? dr["sVoidedUser"].ToString() : "");
                    objlstDonors.bIsStoreVoid = (dr["bIsStoreVoid"] != DBNull.Value ? Convert.ToInt64(dr["bIsStoreVoid"]) : 0);

               
			

                    lstDonors.Add(objlstDonors);
                }
            }
            return lstDonors;
        }


        public Entities.Donors GetDonorsListById(Int64 iDonorId, ref int status)
        {
            Entities.Donors objlstDonors = new Entities.Donors();
            DataTable dt = new DataTable();
            if (iDonorId != 0)
            {
                dt = _Donors.GetDonationTypeListById(iDonorId, ref status);
                if (dt.Rows.Count == 1)
                {

          
                    objlstDonors.iDonorID = (dt.Rows[0]["iDonorId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iDonorId"]) : 0);
                    objlstDonors.sLastName = (dt.Rows[0]["sLastName"] != DBNull.Value ? dt.Rows[0]["sLastName"].ToString() : "");
                    objlstDonors.sFirstName = (dt.Rows[0]["sFirstName"] != DBNull.Value ? dt.Rows[0]["sFirstName"].ToString() : "");
                    objlstDonors.sSpouseName = (dt.Rows[0]["sSpouseName"] != DBNull.Value ? dt.Rows[0]["sSpouseName"].ToString() : "");
                    objlstDonors.sChildrenInfo = (dt.Rows[0]["sChildrenInfo"] != DBNull.Value ? dt.Rows[0]["sChildrenInfo"].ToString() : "");
                    objlstDonors.sStreetName = (dt.Rows[0]["sStreetName"] != DBNull.Value ? dt.Rows[0]["sStreetName"].ToString() : "");
                    objlstDonors.sCity = (dt.Rows[0]["sCity"] != DBNull.Value ? dt.Rows[0]["sCity"].ToString() : "");
                    objlstDonors.sState = (dt.Rows[0]["sState"] != DBNull.Value ? dt.Rows[0]["sState"].ToString() : "");
                    objlstDonors.sZipCode = (dt.Rows[0]["sZipCode"] != DBNull.Value ? dt.Rows[0]["sZipCode"].ToString() : "");
                    objlstDonors.sHomePhone = (dt.Rows[0]["sHomePhone"] != DBNull.Value ? dt.Rows[0]["sHomePhone"].ToString() : "");
                    objlstDonors.sCellPhone = (dt.Rows[0]["sCellPhone"] != DBNull.Value ? dt.Rows[0]["sCellPhone"].ToString() : "");
                    objlstDonors.sEmail = (dt.Rows[0]["sEmail"] != DBNull.Value ? dt.Rows[0]["sEmail"].ToString() : "");
                    objlstDonors.sGothram = (dt.Rows[0]["sGothram"] != DBNull.Value ? dt.Rows[0]["sGothram"].ToString() : "");
                    objlstDonors.sBirthStar = (dt.Rows[0]["sBirthStar"] != DBNull.Value ? dt.Rows[0]["sBirthStar"].ToString() : "");
                    objlstDonors.dDateOfArchana = (dt.Rows[0]["dDateOfArchana"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dDateOfArchana"]) : DateTime.MinValue);
                    objlstDonors.sDayOfArchana = (dt.Rows[0]["sDayOfArchana"] != DBNull.Value ? dt.Rows[0]["sDayOfArchana"].ToString() : "");
                    objlstDonors.iDonorTypeID = (dt.Rows[0]["iDonorTypeId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iDonorTypeId"]) : 0);
                    objlstDonors.dDateOfJoin = (dt.Rows[0]["dDateOfJoin"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dDateOfJoin"]) : DateTime.MinValue);
                    objlstDonors.bActive = (dt.Rows[0]["bActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bActive"]) : false);
                    objlstDonors.dCreateDate = (dt.Rows[0]["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dCreateDate"]) : DateTime.MinValue);
                    objlstDonors.sCreateUser = (dt.Rows[0]["sCreateUser"] != DBNull.Value ? dt.Rows[0]["sCreateUser"].ToString() : "");
                    objlstDonors.dLastUpdateDate = (dt.Rows[0]["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dLastUpdateDate"]) : DateTime.MinValue);
                    objlstDonors.dLastUpdateUser = (dt.Rows[0]["dLastUpdateUser"] != DBNull.Value ? dt.Rows[0]["dLastUpdateUser"].ToString() : "");
                    objlstDonors.sZodiac = (dt.Rows[0]["sZodiac"] != DBNull.Value ? dt.Rows[0]["sZodiac"].ToString() : "");
                    objlstDonors.sSpouseLName = (dt.Rows[0]["sSpouseLName"] != DBNull.Value ? dt.Rows[0]["sSpouseLName"].ToString() : "");
                    objlstDonors.sCountry = (dt.Rows[0]["sCountry"] != DBNull.Value ? dt.Rows[0]["sCountry"].ToString() : "");
                    objlstDonors.sDonorType = (dt.Rows[0]["sDonorType"] != DBNull.Value ? dt.Rows[0]["sDonorType"].ToString() : "");

                 

                }
            }
            return objlstDonors;
        }

        #endregion

        #region Donor List Reports
        public List<Entities.Donors> GetReportsDonorListByVariable(Int64 iDonorTypeID, string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            DataTable dt = _Donors.GetReportsDonorListByVariable(iDonorTypeID, StartDate, EndDate,Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Donors objlstDonors = new Entities.Donors();

                    objlstDonors.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonors.iDonorID = Convert.ToInt32(dr["iDonorID"].ToString());
                    objlstDonors.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");
                    objlstDonors.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objlstDonors.sSpouseName = (dr["sSpouseName"] != DBNull.Value ? dr["sSpouseName"].ToString() : "");
                    objlstDonors.sChildrenInfo = (dr["sChildrenInfo"] != DBNull.Value ? dr["sChildrenInfo"].ToString() : "");
                    objlstDonors.sStreetName = (dr["sStreetName"] != DBNull.Value ? dr["sStreetName"].ToString() : "");
                    objlstDonors.sCity = (dr["sCity"] != DBNull.Value ? dr["sCity"].ToString() : "");
                    objlstDonors.sStateCode = (dr["sStateCode"] != DBNull.Value ? dr["sStateCode"].ToString() : "");
                    objlstDonors.sZipCode = (dr["sZipCode"] != DBNull.Value ? dr["sZipCode"].ToString() : "");
                    objlstDonors.sHomePhone = (dr["sHomePhone"] != DBNull.Value ? dr["sHomePhone"].ToString() : "");
                    objlstDonors.sCellPhone = (dr["sCellPhone"] != DBNull.Value ? dr["sCellPhone"].ToString() : "");
                    objlstDonors.sEmail = (dr["sEmail"] != DBNull.Value ? dr["sEmail"].ToString() : "");
                    objlstDonors.sGothram = (dr["sGothram"] != DBNull.Value ? dr["sGothram"].ToString() : "");
                    objlstDonors.sBirthStar = (dr["sBirthStar"] != DBNull.Value ? dr["sBirthStar"].ToString() : "");
                    objlstDonors.sDonorType = (dr["sDonorType"] != DBNull.Value ? dr["sDonorType"].ToString() : "");
                    objlstDonors.dDateOfArchana = (dr["dDateOfArchana"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfArchana"]) : DateTime.MinValue);
                    objlstDonors.dDateOfJoin = (dr["dDateOfJoin"] != DBNull.Value ? Convert.ToDateTime(dr["dDateOfJoin"]) : DateTime.MinValue);
                    objlstDonors.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);
                    objlstDonors.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                  

                    lstDonors.Add(objlstDonors);
                }
            }
            return lstDonors;
        }

        #endregion


        #region Donor List By Donation Report
        public List<Entities.Donors> GetReportsDonorListByDonationListByVariable(string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            DataTable dt = _Donors.GetReportsDonorListByDonationListByVariable(StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Donors objlstDonors = new Entities.Donors();

                    objlstDonors.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonors.iDonorID = Convert.ToInt32(dr["DonorId"].ToString());
                    objlstDonors.sLastName = (dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "");
                    objlstDonors.sFirstName = (dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "");
                    objlstDonors.sSpouseName = (dr["SpouseName"] != DBNull.Value ? dr["SpouseName"].ToString() : "");
                    objlstDonors.sStreetName = (dr["StreetName"] != DBNull.Value ? dr["StreetName"].ToString() : "");
                    objlstDonors.sCity = (dr["City"] != DBNull.Value ? dr["City"].ToString() : "");
                    objlstDonors.sStateCode = (dr["State"] != DBNull.Value ? dr["State"].ToString() : "");
                    objlstDonors.sZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : "");
                    objlstDonors.sHomePhone = (dr["HomePhone"] != DBNull.Value ? dr["HomePhone"].ToString() : "");
                    objlstDonors.sCellPhone = (dr["CellPhone"] != DBNull.Value ? dr["CellPhone"].ToString() : "");
                    objlstDonors.sEmail = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : "");
                    objlstDonors.TotalDonation = (dr["TotalDonation"] != DBNull.Value ? Convert.ToDecimal(dr["TotalDonation"]) : 0);
                 

                    lstDonors.Add(objlstDonors);
                }
            }
            return lstDonors;
        }

        #endregion


    }
}
