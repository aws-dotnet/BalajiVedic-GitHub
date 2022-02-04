using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
 public class Receipts
	{
		public Int64 RId { get; set; }
		public string ViewButton { get; set; }

		public Int64 iReceiptId { get; set; }
		public DateTime dReceiptDate { get; set; }
		public Int64 iDonorID { get; set; }
		public Int64 iDonorTypeID { get; set; }
		public string sEmail { get; set; }
		public string sComments { get; set; }
		public decimal fAmount { get; set; }

	    public string sCompanyName { get; set; }
		public string sApprovalCode { get; set; }
		public string sRawResponse { get; set; }



		public DateTime dDateOfSponsorship { get; set; }

		public Int64 iPaymentMethodID { get; set; }

		public string sPaymentInfo { get; set; }
		public string sCreateUser { get; set; }
		public DateTime dCreateDate { get; set; }

		public string sLastName { get; set; }
		public string sFirstName { get; set; }
		public string sPaymentMethod { get; set; }
		public string sOtherText { get; set; }
		public Int64 iVoidReceiptId { get; set; }
		public string sVoidReason { get; set; }
		public string sVoidedUser { get; set; }
		public Int64 bIsStoreVoid { get; set; }
		public string ApprovalCode { get; set; }


		public string sName { get; set; }

		public Int64 iReceiptDetailId { get; set; }
		public Int64 iDonationTypeID { get; set; }

		public string Pooja { get; set; }
		public decimal Price { get; set; }
		public DateTime dSponsorDate { get; set; }

                 


	}
}
