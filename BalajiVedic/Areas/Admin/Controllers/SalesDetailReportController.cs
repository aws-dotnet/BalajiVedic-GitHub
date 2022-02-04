using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace BalajiVedic.Areas.Admin.Controllers
{
    public class SalesDetailReportController : Controller
    {

        BLL.SalesDetailReport _SalesDetailReport = new BLL.SalesDetailReport();
        BLL.DonorType _DonorType = new BLL.DonorType();




        #region Reports Sales Services

        public ActionResult ReportsSalesServices()
        {

            return View();
        }

        public ActionResult ReportsSalesServicesList(string StartDate = "", string EndDate = "")
        {

            int status = 0;

            Entities.ReportsSalesServices objReport = new Entities.ReportsSalesServices();

            try
            {
                objReport =  _SalesDetailReport.ReportsSalesServicesGetList(StartDate, EndDate, ref status);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }


            ViewBag.objReport = objReport;
            return View();
        }


        public void ExportToReportsSalesServices(string StartDate = "", string EndDate = "")
        {
            try
            {
                int status = 0;
                BalajiVedic.DAL.SalesDetailReport _DSalesDetailReport = new BalajiVedic.DAL.SalesDetailReport();

                DataTable dtUni = _DSalesDetailReport.ExportToReportsSalesServices(StartDate, EndDate, ref status);

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "ReportsSalesServices-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=ReportsSalesServices-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }


        #endregion


        #region Sales summary Report

        public ActionResult SalesSummaryReport()
        {

            return View();
        }

        public ActionResult SalesSummaryReportList(string StartDate = "", string EndDate = "")
        {
            
            int status = 0;

            Entities.SalesSummaryReport objReport = new Entities.SalesSummaryReport();
            try
            {
                objReport = _SalesDetailReport.SalesSummaryReportGetList(StartDate, EndDate, ref status);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.objReport = objReport;

            return View();
        }
        #endregion

        #region SalesDetailReport List Reports

        public ActionResult SalesDetailReport()
        {
           
            return View();
        }


        public ActionResult SalesDetailReportList(string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.SalesDetailReport> lstSalesDetailReport = new List<Entities.SalesDetailReport>();
            try
            {
                lstSalesDetailReport = _SalesDetailReport.GetReportsReportsSalesDetailByVariable(StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstSalesDetailReport = lstSalesDetailReport;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }



        public void ExportToReportsSalesDetail(string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "")
        {
            try
            {
                BalajiVedic.DAL.SalesDetailReport _DSalesDetailReport = new BalajiVedic.DAL.SalesDetailReport();
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DSalesDetailReport.ExportToReportsSalesDetail(StartDate, EndDate, Search, Sort);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "SalesDetailReport-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=SalesDetailReport-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }

        #endregion

    }
}