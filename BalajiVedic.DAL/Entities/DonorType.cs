using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
  public  class DonorType
    {
        public int RId { get; set; }
        public Int64 iDonorTypeID { get; set; }
        public string sDonorType { get; set; }
        public bool bActive { get; set; }
        public string sCreateUser { get; set; }
        public DateTime dCreateDate { get; set; }
        public string sLastUpdateUser { get; set; }
        public DateTime dLastUpdateDate { get; set; }



        

    }
}
