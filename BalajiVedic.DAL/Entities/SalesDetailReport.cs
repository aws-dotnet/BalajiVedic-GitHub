using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
   public class SalesDetailReport
	{
		public Int64 RId { get; set; }
		public string Type { get; set; }
		public Int64 Receipt_Id { get; set; }

		public DateTime Sale_Date { get; set; }
		public string Last_Name { get; set; }
		public string First_Name { get; set; }
		public string Donation_Desc { get; set; }
		public double fPoojaAmount { get; set; }
		public string Payment_Method { get; set; }
		public string Other_Info { get; set; }
		public string Create_User { get; set; }
		public DateTime Create_Date { get; set; }
		public string sComments { get; set; }
		public string CompanyName { get; set; }

		public string Email { get; set; }
		public string Home_Phone { get; set; }
		public string Cell_Phone { get; set; }
		public string Street_Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }


	}

	public class SalesSummaryReport
        {

		public string sPaymentMethod { get; set; }
		public decimal fAmount { get; set; }

		public decimal TotalAmount { get; set; }

		public decimal TotalVoidAmount { get; set; }
		

		public List<SalesSummaryReport> lstSalesSummaryReport { get; set; }
		public List<SalesSummaryReport> lstVoidReport { get; set; }
		
	}

	public class ReportsSalesServices
	{

		public String Service { get; set; }

		public Int64 Count { get; set; }
		public decimal PriestCommission { get; set; }

		public decimal TotalPriestCommission { get; set; }

		public List<ReportsSalesServices> lstReportsSalesServices { get; set; }
		public Int64 TotalCount { get; set; }

		public decimal Amount { get; set; }

		public decimal TotalAmount { get; set; }

	}


	public class PoojaSponsor
	{
		public Int64 RId { get; set; }
		public DateTime ReceiptDate { get; set; }
		public DateTime SponsorDate { get; set; }
		public Int64 ReceiptId { get; set; }
		public string Pooja { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string SpouseName { get; set; }
		public string ChildrenInfo { get; set; }
		public string HomePhone { get; set; }
		public string CellPhone { get; set; }
		public string Email { get; set; }
		public string Gothram { get; set; }
		public string BirthStar { get; set; }
		public string Zodiac { get; set; }
		public string Comments { get; set; }

	}

}
