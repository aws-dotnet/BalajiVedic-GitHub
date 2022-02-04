using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
    public class ReceiptsController : Controller
    {
        BLL.Receipts _Receipts = new BLL.Receipts();

        public ActionResult Index()
        {
           
            return View();
        }


        public ActionResult ReceiptsList(string sLastName ="",string dReceiptDate = "",Int64 iReceiptId=0,Int64 iDonorId = 0, Int64 iYear = 0, string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Receipts> lstReceipts = new List<Entities.Receipts>();
            try
            {
                lstReceipts = _Receipts.GetReceiptsListByVariable(sLastName, dReceiptDate, iReceiptId, iDonorId, iYear, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstReceipts = lstReceipts;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }



        [HttpPost]
        public ActionResult ReceiptsInsert(Entities.Receipts objReceipts)
        {
            objReceipts.sCreateUser = HttpContext.User.Identity.Name.ToString();
            objReceipts.dCreateDate = DateTime.UtcNow;
          
         
            try
            {
                Int64 _status = _Receipts.ReceiptsInsert(objReceipts);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Inserted Record.</div>";
                    return RedirectToAction("Index", "Donors");
                }
              
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading Record.</div>";
                    return RedirectToAction("Index", "Donors");
                }
            }
            catch (Exception EX)
            {
                TempData["message"] = "<div class=\"error closable\">" + EX.Message + "</div>";
                return RedirectToAction("Index", "Donors");
            }
        }


        public ActionResult ViewReceipt(Int64 iReceiptId = 0)
        {

            Entities.Receipts objReceipts = new Entities.Receipts();

            int status = 0;

            try
            {
                int _qstatus = 0;
                objReceipts = _Receipts.ReceiptsGetById(iReceiptId, ref status);
            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Receipts");
            }
            ViewBag.objReceiptviews = objReceipts;
            return View();
        }



        public ActionResult ReceiptViewList(Int64 iReceiptId=0,string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Receipts> lstReceipts = new List<Entities.Receipts>();
            try
            {
                lstReceipts = _Receipts.GetReceiptViewListByVariable(iReceiptId,Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstReceiptviews = lstReceipts;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }


    }
}