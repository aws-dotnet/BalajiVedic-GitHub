using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
    public class PriestController : Controller
    {
        #region Priest 

        BLL.Priest _DonorType = new BLL.Priest();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PriestList(string Search = "", string SortColumn = "iPriestId", string SortOrder = "DESC", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Priest> lstPriest = new List<Entities.Priest>();
            try
            {
                lstPriest = _DonorType.GetPriestListByVariable(Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstPriest = lstPriest;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }

        [HttpPost]
        public ActionResult InsertPriest(Entities.Priest objDonorType)
        {
            objDonorType.sCreateUser = HttpContext.User.Identity.Name.ToString();
            objDonorType.dCreateDate = DateTime.UtcNow;
            objDonorType.sUpdateUser = HttpContext.User.Identity.Name.ToString();
            objDonorType.dUpdateDate = DateTime.UtcNow;
            objDonorType.bActive = true;
            try
            {
                Int64 _status = _DonorType.InsertPriest(objDonorType);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Inserted Record.</div>";
                    return RedirectToAction("Index", "Priest");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Updated Record.</div>";
                    return RedirectToAction("Index", "Priest");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading Record.</div>";
                    return RedirectToAction("Index", "Priest");
                }
            }
            catch (Exception EX)
            {
                TempData["message"] = "<div class=\"error closable\">" + EX.Message + "</div>";
                return RedirectToAction("Index", "Priest");
            }
        }

        [HttpPost]
        public ActionResult EditPriest(Int64 iPriestId)
        {
            string str = "";
            try
            {
                Int32 _qstatus = 0;
                Entities.Priest _objPriest = _DonorType.GetPriestListById(iPriestId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objPriest });
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
        public ActionResult DeletePriest(Int64 iPriestId)
        {
            string str = "";
            try
            {
                Int64 _status = _DonorType.DeletePriest(iPriestId);
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
        public JsonResult UpdatePriestStatus(Int64 iPriestId)
        {
            string str = "";
            try
            {
                Int64 _status = _DonorType.UpdatePriestStatus(iPriestId);
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