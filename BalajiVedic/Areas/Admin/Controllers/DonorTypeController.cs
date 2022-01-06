using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
 
    public class DonorTypeController : Controller
    {
        #region DonorType 

        BLL.DonorType _DonorType = new BLL.DonorType();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonorTypeList(string Search = "", string SortColumn = "dCreateDate", string SortOrder = "DESC", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.DonorType> lstDonorType = new List<Entities.DonorType>();
            try
            {
                lstDonorType = _DonorType.GetDonorTypeListByVariable(Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstDonorType = lstDonorType;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }

        [HttpPost]
        public ActionResult InsertDonorType(Entities.DonorType objDonorType)
        {
            objDonorType.sCreateUser = HttpContext.User.Identity.Name.ToString();
            objDonorType.dCreateDate = DateTime.UtcNow;
            objDonorType.sLastUpdateUser = HttpContext.User.Identity.Name.ToString();
            objDonorType.dLastUpdateDate = DateTime.UtcNow;
            try
            {
                Int64 _status = _DonorType.InsertDonorType(objDonorType);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Inserted Record.</div>";
                    return RedirectToAction("Index", "DonorType");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Updated Record.</div>";
                    return RedirectToAction("Index", "DonorType");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading Record.</div>";
                    return RedirectToAction("Index", "DonorType");
                }
            }
            catch (Exception EX)
            {
                TempData["message"] = "<div class=\"error closable\">" + EX.Message + "</div>";
                return RedirectToAction("Index", "DonorType");
            }
        }

        [HttpPost]
        public ActionResult EditDonorType(Int64 iDonorTypeID)
        {
            string str = "";
            try
            {
                Int32 _qstatus = 0;
                Entities.DonorType _objCountry = _DonorType.GetCountrysById(iDonorTypeID, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objCountry });
                }
                else
                {
                    str = "<div class=\"success closable\">Failed Transaction</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch (Exception ex)
            {
                str = "<div class=\"error closable\">" + ex.Message + "</div>";
                return Json(new { ok = false, data = str });
            }
        }


    
        [HttpPost]
        public ActionResult DeleteDonorType(Int64 iDonorTypeID)
        {
            string str = "";
            try
            {
                Int64 _status = _DonorType.DeleteDonorType(iDonorTypeID);
                if (_status == 1)
                {
                    str = "<li class=\"success closable\">Deleted Record successfully</li>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<li class=\"error closable\">Failed to Delete Record</li>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch (Exception ex)
            {
                str = "<li class=\"error closable\">" + ex.Message + "</li>";
                return Json(new { ok = true, data = str });
            }
        }


   
        [HttpPost]
        public JsonResult UpdateDonorTypeStatus(Int64 iDonorTypeID)
        {
            string str = "";
            try
            {
                Int64 _status = _DonorType.UpdateDonorTypeStatus(iDonorTypeID);
                if (_status == 1)
                {
                    str = "<li class=\"success closable\">Updated status successfully</li>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<li class=\"error closable\">Failed updating status</li>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<li class=\"error closable\">Failed transaction.</li>";
                return Json(new { ok = true, data = str });
            }
        }




        #endregion

    }
}
