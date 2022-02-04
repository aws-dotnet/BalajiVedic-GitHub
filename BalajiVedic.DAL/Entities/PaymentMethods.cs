using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
  public  class PaymentMethods
    {
        public Int64 RId { get; set; }
        public Int64 iPaymentMethodID { get; set; }
        public string sPaymentMethod { get; set; }
        public string sOtherText  { get; set; }

        public bool bActive { get; set; }
        public string sCreateUser { get; set; }

        public DateTime dCreateDate { get; set; }
        public string sLastUpdateUser { get; set; }
        public DateTime dLastUpdateDate { get; set; }
     
    }
}
