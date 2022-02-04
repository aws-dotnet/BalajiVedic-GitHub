using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
    public class DonationType
    {
        public Int64 RId { get; set; }
        public Int64 iDonationTypeID { get; set; }

        public string sDonationTypeDesc { get; set; }
        public double fPrice { get; set; }
        public double dPriestCommission {get;set;}
        public string sDonationType { get; set; }
        public bool bActive { get; set; }
        public bool bTaxDeductible { get; set; }
        public string sCreateUser { get; set; }
        public DateTime dCreateUser { get; set; }

        public string sLastUpdateUser { get; set; }
        public DateTime dLastUpdateDate { get; set; }
        public string sNotes { get; set; }
        public string sPoojaFrequency { get; set; }
        public double fPriestCommision { get; set; }
        public string sPriestCommissionBased { get; set; }

        public string CommissionType { get; set; }

        public string sDonorType { get; set; }



    }
}
