using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
    public class PaymentMethodsController : Controller
    {
        BLL.PaymentMethods _paymentMethods = new BLL.PaymentMethods();
        List<Entities.PaymentMethods> lstPaymentMethods = new List<Entities.PaymentMethods>();
        public ActionResult Index(string sLastName = "", string sFirstName = "", Int64 iDonorId = 0, string sPhoneNumber = "")
        {

            ViewBag.sLastName = sLastName;
            ViewBag.sFirstName = sFirstName;
            ViewBag.iDonorId = iDonorId;
            ViewBag.sPhoneNumber = sPhoneNumber;

            return View();
        }

        public ActionResult PaymentMethodsList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstPaymentMethods = _paymentMethods.GetPaymentMethodsListByVariable(Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstPaymentMethods = lstPaymentMethods;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }



    }
}