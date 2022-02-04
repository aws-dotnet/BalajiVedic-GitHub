using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
   public class PoojaSponsor
    {

        //kiran
        DAL.PoojaSponsor _Donors = new DAL.PoojaSponsor();

        #region Donor List Reports
        public List<Entities.PoojaSponsor> GetReportsPoojaSponsorListByVariable(Int64 iPoojaId, string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.PoojaSponsor> lstDonors = new List<Entities.PoojaSponsor>();
            DataTable dt = _Donors.GetReportsPoojaSponsorListByVariable(iPoojaId, StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.PoojaSponsor objPoojaSponsor = new Entities.PoojaSponsor();

                    objPoojaSponsor.RId = Convert.ToInt32(dr["RId"].ToString());
                    objPoojaSponsor.ReceiptDate = (dr["ReceiptDate"] != DBNull.Value ? Convert.ToDateTime(dr["ReceiptDate"]) : DateTime.MinValue);
                    objPoojaSponsor.SponsorDate = (dr["SponsorDate"] != DBNull.Value ? Convert.ToDateTime(dr["SponsorDate"]) : DateTime.MinValue);
                    objPoojaSponsor.ReceiptId = (dr["ReceiptId"] != DBNull.Value ? Convert.ToInt64(dr["ReceiptId"]) : 0);
                    objPoojaSponsor.Pooja = (dr["Pooja"] != DBNull.Value ? dr["Pooja"].ToString() : "");
                    objPoojaSponsor.LastName = (dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "");
                    objPoojaSponsor.FirstName = (dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "");
                    objPoojaSponsor.SpouseName = (dr["SpouseName"] != DBNull.Value ? dr["SpouseName"].ToString() : "");
                    objPoojaSponsor.ChildrenInfo = (dr["ChildrenInfo"] != DBNull.Value ? dr["ChildrenInfo"].ToString() : "");
                    objPoojaSponsor.HomePhone = (dr["HomePhone"] != DBNull.Value ? dr["HomePhone"].ToString() : "");
                    objPoojaSponsor.CellPhone = (dr["CellPhone"] != DBNull.Value ? dr["CellPhone"].ToString() : "");
                    objPoojaSponsor.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : "");
                    objPoojaSponsor.Gothram = (dr["Gothram"] != DBNull.Value ? dr["Gothram"].ToString() : "");
                    objPoojaSponsor.BirthStar = (dr["BirthStar"] != DBNull.Value ? dr["BirthStar"].ToString() : "");
                    objPoojaSponsor.Zodiac = (dr["Zodiac"] != DBNull.Value ? dr["Zodiac"].ToString() : "");
                    objPoojaSponsor.Comments = (dr["Comments"] != DBNull.Value ? dr["Comments"].ToString() : "");
  

                    lstDonors.Add(objPoojaSponsor);
                }
            }
            return lstDonors;
        }

        #endregion

    }
}
