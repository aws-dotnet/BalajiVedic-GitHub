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

    }
}
