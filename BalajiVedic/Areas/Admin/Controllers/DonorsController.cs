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
    public class DonorsController : Controller
    {

        BLL. Donors _Donors = new BLL. Donors();
        BLL.DonorType _DonorType = new BLL.DonorType();
        List<Entities.DonorType> lstDonorType = new List<Entities.DonorType>();

        #region Donors List Reports
        public ActionResult ReportsDonor()
        {
            int status = 0;
            lstDonorType = _DonorType.GetDonorTypeList(ref status);

            ViewBag.lstDonorType = lstDonorType;
            return View();
        }


        public ActionResult ReportsDonorList(Int64 iDonorTypeID=0,string StartDate ="",string EndDate="",string Search = "", string SortColumn = "dLastUpdateDate", string SortOrder = "DESC", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities. Donors> lstDonors = new List<Entities. Donors>();
            try
            {
                lstDonors = _Donors.GetReportsDonorListByVariable(iDonorTypeID, StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstDonors = lstDonors;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }

        

        public void ExportToReportsDonorList(Int64 iDonorTypeID=0,string StartDate = "", string EndDate = "", string Search = "",string SortColumn = "dLastUpdateDate", string SortOrder = "DESC")
        {
            try
            {
                BalajiVedic.DAL.Donors _DPreLeads = new BalajiVedic.DAL.Donors();
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DPreLeads.ExportToReportsDonorList(iDonorTypeID, StartDate, EndDate, Search,Sort);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Donors-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Donors-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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