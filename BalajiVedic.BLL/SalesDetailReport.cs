using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
  public  class SalesDetailReport
    {

        //kiran
        DAL.SalesDetailReport _Donors = new DAL.SalesDetailReport();

        #region Report Sale Services
        //public List<Entities.ReportsSalesServices> ReportsSalesServicesGetList(string StartDate, string EndDate, ref int status)
        //{
        //    List<Entities.ReportsSalesServices> lstReportsSalesServices = new List<Entities.ReportsSalesServices>();
        //    DataTable dt = _Donors.ReportsSalesServicesGetList(StartDate, EndDate,ref status);
        //    if (dt.Rows.Count != 0)
        //    {
        //        decimal TotalPriestCommission = 0;
        //        decimal TotalAmount = 0;
        //        Int64 TotalCount = 0;

        //        Entities.ReportsSalesServices objReport = new Entities.ReportsSalesServices();


        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            Entities.ReportsSalesServices objReportsSalesServices = new Entities.ReportsSalesServices();

        //            objReportsSalesServices.Service = (dr["Service"] != DBNull.Value ? dr["Service"].ToString() : "");
                    
        //            objReportsSalesServices.Count = (dr["Count"] != DBNull.Value ? Convert.ToInt64(dr["Count"]) : 0);
        //            TotalCount = TotalCount  + objReportsSalesServices.Count;
        //            objReport.TotalCount = objReportsSalesServices.TotalCount + TotalCount;


        //            objReportsSalesServices.PriestCommission = (dr["PriestCommission"] != DBNull.Value ? Convert.ToDecimal(dr["PriestCommission"]) : 0);
        //            TotalPriestCommission = TotalPriestCommission  + objReportsSalesServices.PriestCommission;
        //            objReport.TotalPriestCommission = objReportsSalesServices.TotalPriestCommission + TotalPriestCommission;

        //            objReportsSalesServices.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
        //            TotalAmount = TotalAmount  + objReportsSalesServices.Amount;
        //            objReport.TotalAmount = objReportsSalesServices.TotalAmount + TotalAmount;

        //            lstReportsSalesServices.Add(objReportsSalesServices);
        //        }

        //         objReport.TotalCount = objReport.TotalCount;
        //        objReport.TotalPriestCommission = objReport.TotalPriestCommission;
        //        objReport.TotalAmount = objReport.TotalAmount;

        //        lstReportsSalesServices.Add(objReport);
        //    }





        //    return lstReportsSalesServices;


        //}


        public Entities.ReportsSalesServices ReportsSalesServicesGetList(string StartDate, string EndDate, ref int status)
        {
            Entities.ReportsSalesServices objReport = new  Entities.ReportsSalesServices();
            List<Entities.ReportsSalesServices> lstReportsSalesServices = new List<Entities.ReportsSalesServices>();

            
                DataSet dt = _Donors.ReportsSalesServicesGetList(StartDate, EndDate, ref status);


               if (dt.Tables[0].Rows.Count != 0)
                {
                decimal TotalPriestCommission = 0;
                decimal TotalAmount = 0;
                Int64 TotalCount = 0;

                foreach (DataRow dr in dt.Tables[0].Rows)
                    {
                    Entities.ReportsSalesServices objReportsSalesServices = new Entities.ReportsSalesServices();

                    objReportsSalesServices.Service = (dr["Service"] != DBNull.Value ? dr["Service"].ToString() : "");

                    objReportsSalesServices.Count = (dr["Count"] != DBNull.Value ? Convert.ToInt64(dr["Count"]) : 0);
                    TotalCount = TotalCount + objReportsSalesServices.Count;
                    objReport.TotalCount = objReportsSalesServices.TotalCount + TotalCount;


                    objReportsSalesServices.PriestCommission = (dr["PriestCommission"] != DBNull.Value ? Convert.ToDecimal(dr["PriestCommission"]) : 0);
                    TotalPriestCommission = TotalPriestCommission + objReportsSalesServices.PriestCommission;
                    objReport.TotalPriestCommission = objReportsSalesServices.TotalPriestCommission + TotalPriestCommission;

                    objReportsSalesServices.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    TotalAmount = TotalAmount + objReportsSalesServices.Amount;
                    objReport.TotalAmount = objReportsSalesServices.TotalAmount + TotalAmount;


                    lstReportsSalesServices.Add(objReportsSalesServices);
                }
                }

             objReport.lstReportsSalesServices = lstReportsSalesServices;

            objReport.TotalCount = objReport.TotalCount;
            objReport.TotalPriestCommission = objReport.TotalPriestCommission;
            objReport.TotalAmount = objReport.TotalAmount;

           
            return objReport;
        }





        #endregion


        #region Sales Summart Report


        public Entities.SalesSummaryReport SalesSummaryReportGetList(string StartDate, string EndDate, ref int status)
        {
            Entities.SalesSummaryReport objReport = new Entities.SalesSummaryReport();
            List<Entities.SalesSummaryReport> lstSalesSummaryReport = new List<Entities.SalesSummaryReport>();
            List<Entities.SalesSummaryReport> lstVoidReport = new List<Entities.SalesSummaryReport>();

            
            DataSet dt = _Donors.SalesSummaryReportGetList(StartDate, EndDate, ref status);


            if (dt.Tables[0].Rows.Count != 0)
            {
               
                decimal TotalAmount = 0;
                decimal TotalVoidAmount = 0;

                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    Entities.SalesSummaryReport objSaleReport = new Entities.SalesSummaryReport();

                  

                    objSaleReport.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objSaleReport.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDecimal(dr["fAmount"].ToString()) : 0);

                    TotalAmount = TotalAmount + objSaleReport.fAmount;
                    objReport.TotalAmount = objSaleReport.TotalAmount + TotalAmount;

                    lstSalesSummaryReport.Add(objSaleReport);


                    
                }
            }

            objReport.lstSalesSummaryReport = lstSalesSummaryReport;
            objReport.TotalAmount = objReport.TotalAmount;


            if (dt.Tables[1].Rows.Count != 0)
            {

             
                decimal TotalVoidAmount = 0;

                foreach (DataRow dr in dt.Tables[1].Rows)
                {
                    Entities.SalesSummaryReport objVoidSaleReport = new Entities.SalesSummaryReport();



                    objVoidSaleReport.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objVoidSaleReport.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDecimal(dr["fAmount"].ToString()) : 0);

                    TotalVoidAmount = TotalVoidAmount + objVoidSaleReport.fAmount;
                    objReport.TotalVoidAmount = objVoidSaleReport.TotalVoidAmount + TotalVoidAmount;

                    lstVoidReport.Add(objVoidSaleReport);



                }
            }

            objReport.lstVoidReport = lstVoidReport;
            objReport.TotalVoidAmount = objReport.TotalVoidAmount;


            return objReport;
        }





        //public void SalesSummaryReportGetList(string StartDate, string EndDate,
        // ref List<Entities.SalesSummaryReport> lstSaleReport,
        // ref List<Entities.SalesSummaryReport> lstVoidReport,

  
       
        // ref int status)
        //{
        //    DataSet ds = _Donors.SalesSummaryReportGetList(StartDate, EndDate, ref status);



        //    //Sales
           
        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            Entities.SalesSummaryReport objSaleReport = new Entities.SalesSummaryReport();

        //            objSaleReport.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
        //            objSaleReport.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDouble(dr["fAmount"].ToString()) : 0);

        //            lstSaleReport.Add(objSaleReport);
        //        }
        //    }


        //    //Voids
        //    if (ds.Tables[1].Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[1].Rows)
        //        {
        //            Entities.SalesSummaryReport objVoidReport = new Entities.SalesSummaryReport();

        //            objVoidReport.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
        //            objVoidReport.fAmount = (dr["fAmount"] != DBNull.Value ? Convert.ToDouble(dr["fAmount"].ToString()) : 0);

        //            lstSaleReport.Add(objVoidReport);
        //        }
        //    }


        //}

        #endregion

        #region Sales DetailReport
        public List<Entities.SalesDetailReport> GetReportsReportsSalesDetailByVariable(string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.SalesDetailReport> lstDonors = new List<Entities.SalesDetailReport>();
            DataTable dt = _Donors.GetReportsReportsSalesDetailByVariable(StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.SalesDetailReport objSalesDetailReport = new Entities.SalesDetailReport();

                    objSalesDetailReport.RId = Convert.ToInt32(dr["RId"].ToString());
                    objSalesDetailReport.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : "");
                    objSalesDetailReport.Receipt_Id = Convert.ToInt32(dr["Receipt_Id"].ToString());
                    objSalesDetailReport.Last_Name = (dr["Last_Name"] != DBNull.Value ? dr["Last_Name"].ToString() : "");
                    objSalesDetailReport.First_Name = (dr["First_Name"] != DBNull.Value ? dr["First_Name"].ToString() : "");
                    objSalesDetailReport.Donation_Desc = (dr["Donation_Desc"] != DBNull.Value ? dr["Donation_Desc"].ToString() : "");
                    objSalesDetailReport.fPoojaAmount = (dr["fPoojaAmount"] != DBNull.Value ? Convert.ToDouble(dr["fPoojaAmount"]) : 0);
                    objSalesDetailReport.Payment_Method = (dr["Payment_Method"] != DBNull.Value ? dr["Payment_Method"].ToString() : "");
                    objSalesDetailReport.Other_Info = (dr["Other_Info"] != DBNull.Value ? dr["Other_Info"].ToString() : "");
                    objSalesDetailReport.Create_User = (dr["Create_User"] != DBNull.Value ? dr["Create_User"].ToString() : "");
                    objSalesDetailReport.Create_Date = (dr["Create_Date"] != DBNull.Value ? Convert.ToDateTime(dr["Create_Date"]) : DateTime.MinValue);
                    objSalesDetailReport.sComments = (dr["sComments"] != DBNull.Value ? dr["sComments"].ToString() : "");
                    objSalesDetailReport.CompanyName = (dr["CompanyName"] != DBNull.Value ? dr["CompanyName"].ToString() : "");
                    objSalesDetailReport.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : "");
                    objSalesDetailReport.Home_Phone = (dr["Home_Phone"] != DBNull.Value ? dr["Home_Phone"].ToString() : "");
                    objSalesDetailReport.Cell_Phone = (dr["Cell_Phone"] != DBNull.Value ? dr["Cell_Phone"].ToString() : "");
                    objSalesDetailReport.Street_Name = (dr["Street_Name"] != DBNull.Value ? dr["Street_Name"].ToString() : "");
                    objSalesDetailReport.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : "");
                    objSalesDetailReport.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : "");
                    objSalesDetailReport.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : "");
                    


                    lstDonors.Add(objSalesDetailReport);
                }
            }
            return lstDonors;
        }

        #endregion
    }
}
