using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
    public class DonationTypeController : Controller
    {
        #region DonationType 

        BLL.DonationType _DonationType = new BLL.DonationType();
        List<Entities.DonationType> lstDonationType = new List<Entities.DonationType>();
        public ActionResult Index()
        {
            int Total = 0;
           
            return View();
        }

        public ActionResult DonationTypeList(string ddlType = "",string Search = "", string SortColumn = "dCreateUser", string SortOrder = "DESC", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstDonationType = _DonationType.GetDonationTypeListByVariable(ddlType, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstDonationType = lstDonationType;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }


        public ActionResult AddDonationType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertDonationType(Entities.DonationType objDonationType)
        {
            objDonationType.sCreateUser = HttpContext.User.Identity.Name.ToString();
            objDonationType.dCreateUser = DateTime.UtcNow;
            objDonationType.sLastUpdateUser = HttpContext.User.Identity.Name.ToString();
            objDonationType.dLastUpdateDate = DateTime.UtcNow;
            try
            {
                Int64 _status = _DonationType.InsertDonationType(objDonationType);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Inserted Record.</div>";
                    return RedirectToAction("Index", "DonationType");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Updated Record.</div>";
                    return RedirectToAction("Index", "DonationType");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading Record.</div>";
                    return RedirectToAction("Index", "DonationType");
                }
            }
            catch (Exception EX)
            {
                TempData["message"] = "<div class=\"error closable\">" + EX.Message + "</div>";
                return RedirectToAction("Index", "DonationType");
            }
        }

   
        public ActionResult EditDonationType(Int64 iDonationTypeID)
        {
            Entities.DonationType objDonationType = new Entities.DonationType();
         
            int status = 0;
           
            try
            {
                int _qstatus = 0;
                objDonationType = _DonationType.GetDonationTypeListById(iDonationTypeID, ref status);
               
               

            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "DonationType");
            }
            ViewBag.objDonationType = objDonationType;
            return View();
        }


        [HttpPost]
        public ActionResult DeleteDonationType(Int64 iDonationTypeID)
        {
            string str = "";
            try
            {
                Int64 _status = _DonationType.DonationTypeDelete(iDonationTypeID);
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
        public JsonResult UpdateDonationTypeStatus(Int64 iDonationTypeID)
        {
            string str = "";
            try
            {
                Int64 _status = _DonationType.UpdateDonationTypeStatus(iDonationTypeID);
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


        #region Pooja/Donation list


        public ActionResult PoojaDonations(string sFrequency="",string sLastName="",string sFirstName="",Int64 iDonorId=0,string sPhoneNumber="")
        {
            ViewBag.sFrequency = sFrequency;
            ViewBag.sLastName = sLastName;
            ViewBag.sFirstName = sFirstName;
            ViewBag.iDonorId = iDonorId;
            ViewBag.sPhoneNumber = sPhoneNumber;

            return View();
        }

        public ActionResult PoojaDonationsList(string sFrequency = "", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstDonationType = _DonationType.GetPoojaDonationsListByVariable(sFrequency, Search, Sort, PageNo, Items, ref Total);
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstDonationType = lstDonationType;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Search = Search;
            return View();
        }

        [HttpPost]
        public ActionResult DonationTypeNotesUpdate(Entities.DonationType objDonationType)
        {

            try
            {
                

                Int64 _status = _DonationType.DonationTypeNotesUpdate(objDonationType);
                if (_status == 2)
                {


                    string msg = "<div class=\"success closable\">Updated  Successfully</div>";
                    return Json(new { ok = true, data = msg });
                }
                else
                {
                    string msg = "<div class=\"error closable\">Failed uploading page.</div>";
                    return Json(new { ok = false, data = msg });
                }
            }
            catch (Exception ex)
            {
                string msg = "<div class=\"error closable\">" + ex.Message + ".</div>";
                return Json(new { ok = false, data = msg });
            }
        }




        #endregion
    }
}