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
    public class PoojaSponsorController : Controller
    {

        BLL.PoojaSponsor _Donors = new BLL.PoojaSponsor();
        BLL.DonationType _DonationType = new BLL.DonationType();
        List<Entities.DonationType> lstDonationType = new List<Entities.DonationType>();
      


        #region PoojaSponsor List Reports

        public ActionResult PoojaSponsor()
        {
            int status = 0;
            lstDonationType = _DonationType.GetDonationTypeList(ref status);

            ViewBag.lstDonationType = lstDonationType;
            return View();
        }


        public ActionResult PoojaSponsorList(Int64 iPoojaId = 0, string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.PoojaSponsor> lstPoojaSponsor = new List<Entities.PoojaSponsor>();
            try
            {
                lstPoojaSponsor = _Donors.GetReportsPoojaSponsorListByVariable(iPoojaId, StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstPoojaSponsor = lstPoojaSponsor;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }



        public void ExportToReportsPoojaSponsorList(Int64 iPoojaId = 0, string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "")
        {
            try
            {
                BalajiVedic.DAL.PoojaSponsor _DPreLeads = new BalajiVedic.DAL.PoojaSponsor();
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DPreLeads.ExportToReportsPoojaSponsorList(iPoojaId, StartDate, EndDate, Search, Sort);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "PoojaSponsor-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=PoojaSponsor-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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