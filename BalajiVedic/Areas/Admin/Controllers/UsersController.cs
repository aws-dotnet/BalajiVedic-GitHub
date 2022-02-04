using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalajiVedic.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        BLL.Users _user = new BLL.Users();

       
        public ActionResult Index()
        {
           
            return View();
        }

       
        public ActionResult UserList(string sUserID="", string Name="", Int64 iRoleID=0, string Search = "",string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Users> lstuser = new List<Entities.Users>();
            try
            {
                lstuser = _user.GetUsersListByVariable(sUserID, Name, iRoleID,Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstuser = lstuser;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }


        public ActionResult AddUser()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CreateUser(Entities.Users objUsers)
        {
            try
            {
                Guid guid = BalajiVedic.BLL.Common.generateGUID();
                objUsers.sCreateUser = HttpContext.User.Identity.Name.ToString();
                objUsers.dCreateDate = DateTime.UtcNow;
                objUsers.sLastUpdateUser = HttpContext.User.Identity.Name.ToString();
                objUsers.dLastUpdateDate = DateTime.UtcNow;
               // objUsers.bActive = true;
              //  objUsers.bForcePasswordChange = false;
              //  objUsers.bLockOut = false;
                string newpass = BLL.Password.GetUniqueKey(8);
                objUsers.sPassword = BalajiVedic.BLL.Password.EncryptPassword(newpass);


                Int64 _status = _user.InsertUsers(objUsers);
                if (_status == 1)
                {
                  
                    TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Created user account with sFirstName " + objUsers.sFirstName + ".</div>";
                    return RedirectToAction("Index", "Users");
                }

                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Updated Record.</div>";
                    return RedirectToAction("Index", "Users");
                }

                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed uploading image.</div>";
                    return RedirectToAction("Index", "Users");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Users");
            }
        }

       
      

        public ActionResult EditUser(Int64 iUserID)
        {
            Entities.Donors objDonors = new Entities.Donors();

            int status = 0;

            try
            {
                int _qstatus = 0;
                Entities.Users _objuser = _user.GetUsersListById(iUserID, ref _qstatus);
                ViewBag.objUsers = _objuser;


            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Users");
            }
          
            return View();
        }






        [HttpPost]
        public JsonResult UpdateUsersStatus(Int64 iUserID)
        {
            string str = "";
            try
            {
                Int64 _status = _user.UpdateUsersStatus(iUserID);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Updated Status Successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed updating user status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                return Json(new { ok = true, data = str });
            }
        }


    
        [HttpPost]
        public JsonResult UserDelete(Int64 iUserID)
        {
            string str = "";
            try
            {
                Int64 _status = _user.DeleteUsers(iUserID);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Record Deleted Successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed deleting user status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

  
    }
}