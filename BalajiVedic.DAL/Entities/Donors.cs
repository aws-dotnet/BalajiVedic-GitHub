using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
   public class Donors
    {
        public Int64 RId { get; set; }
        public Int64 iDonorID { get; set; }
        public string sLastName { get; set; }
        public string sFirstName { get; set; }
        public string sSpouseName { get; set; }
        public string sChildrenInfo { get; set; }
        public string sStreetName { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public string sZipCode { get; set; }
        public string sHomePhone { get; set; }
        public string sCellPhone { get; set; }
        public string sEmail { get; set; }

        public string sStateCode { get; set; }
        public string sGothram { get; set; }
        public string sBirthStar { get; set; }
        public DateTime dDateOfArchana { get; set; }
        public Int64 iDonorTypeID { get; set; }
        public DateTime dDateOfJoin { get; set; }
        public bool bActive { get; set; }
        public string sDonorType { get; set; }

        public DateTime dCreateDate { get; set; }
        public string sCreateUser { get; set; }

        public DateTime dLastUpdateUser { get; set; }
        public DateTime dLastUpdateDate { get; set; }
        public string sZodiac { get; set; }
        public string sSpouseLName { get; set; }
        public string sCountry { get; set; }

    }
}
