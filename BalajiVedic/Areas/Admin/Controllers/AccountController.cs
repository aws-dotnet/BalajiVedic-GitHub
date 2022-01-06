using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Configuration;
using BalajiVedic.Entities;
using System.Text;
using BalajiVedic.Areas.Admin.Models;
using System.Web.Helpers;

namespace BalajiVedic.Areas.Admin.Controllers
{   
    public class AccountController : Controller
    {
        BalajiVedic.BLL.Users _user = new BalajiVedic.BLL.Users();

        public ActionResult LogOn(string str = "")
        {
            
            if (str == "session")
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Session Expired.</div>";
            }
            if (str == "noaccess")
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Admin need to provide role access.</div>";
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(Users model, string returnUrl)
        {
            try
            {
                int _status = 0;
                Entities.Users objUser = _user.GetUsersListBysUserId(model.sUserID, ref _status);
                if (objUser != null && objUser.iUserID != 0 && objUser.RoleName != "EndUser")
                {
                    if (objUser.bActive == true)
                    {
                        int _qstatus = 0;
                        string Email = "";
                        string password = _user.GetPassword(objUser.iUserID,ref _qstatus);
                        if (_qstatus == 1)
                        {
                            string pwd = BLL.Password.UnEncryptPassword(password);
                            
              
                            if (model.sPassword.Trim() == pwd )
                            {
                                Int64 status = 0;
                                Session["username"] = HttpContext.User.Identity.Name.ToString();
                                Session["userrole"] = objUser.RoleName;
                                string UserRole = objUser.RoleName;

                                var authTicket = new FormsAuthenticationTicket(
                                  1,                             // version
                                  objUser.sFirstName,              // user name
                                  DateTime.UtcNow,                  // created
                                  DateTime.UtcNow.AddMinutes(20),   // expires
                                  model.RememberMe,              // persistent?
                                  objUser.RoleName);


                                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                                var authCookie = new HttpCookie("UserCookie", encryptedTicket);
                                HttpContext.Response.Cookies.Add(authCookie);
                                

                                if (UserRole.Contains("SubAdmin"))
                                { return RedirectToAction("Index", "DonorType"); }
                                else if (UserRole.Contains("SystemAdmin"))
                                { return RedirectToAction("Index", "DonorType"); }
                                else if (UserRole.Contains("Volunteers") || UserRole.Contains("SystemAdmin"))
                                { return RedirectToAction("Index", "DonorType"); }
                                else if (UserRole.Contains("Events"))
                                { return RedirectToAction("Index", "Events"); }
                                else if (UserRole.Contains("Enquiries"))
                                { return RedirectToAction("Index", "Enquiry"); }
                                else if (UserRole.Contains("Photos"))
                                { return RedirectToAction("Index", "PhotoGallery"); }
                                else if (UserRole.Contains("Videos"))
                                { return RedirectToAction("Index", "VideoGallery"); }
                                else if (UserRole.Contains("Committees"))
                                { return RedirectToAction("Index", "Committees"); }
                                else if (UserRole.Contains("Youth"))
                                { return RedirectToAction("Index", "Youth"); }
                                else if (UserRole.Contains("SubAdmin") || UserRole.Contains("Members"))
                                { return RedirectToAction("Index", "Members"); }
                                else if (UserRole.Contains("Sponsors"))
                                { return RedirectToAction("Index", "Sponsors"); }
                                else if (UserRole.Contains("ThemeBanners"))
                                { return RedirectToAction("Index", "WebsiteBanners"); }
                                else if (UserRole.Contains(""))
                                {
                                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Admin need to provide role access.</div>";
                                    return RedirectToAction("LogOn", "Account", new { str = "noaccess" });
                                }

                            }
                           
                        }
                        else
                        {
                            TempData["message"] = "<div class=\"error closable\">Email or password is incorrect.</div>";
                        }
                    }
                    else
                    {
                        TempData["message"] = "<div class=\"error closable\">Your status has been deactivated.Please contact to admin.</div>";
                    }
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Email or password is incorrect.</div>";
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }
            return RedirectToAction("LogOn", "Account");
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogOn", "Account");
        }

        #region Profile

        public ActionResult ChangePassword()
        {
            int _qstatus = 0;
            Entities.Users _objuser = new Entities.Users();
            try
            {
                _objuser = _user.GetUsersListBysUserId(HttpContext.User.Identity.Name.ToString(), ref _qstatus);
            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
            }

            ViewBag.objuser = _objuser;
            return View();
        }


        [Authorize]
        [HttpPost]
       
        public ActionResult ChangePassword(Users model)
        {
            try
            {
                if (model.iUserID != 0)
                {
                    int _qstatus = 0;
                    string Email = "";
                    string oldpass = _user.GetPassword(model.iUserID,  ref _qstatus);

                    if (_qstatus == 1)
                    {
                        string oldpwd = BLL.Password.UnEncryptPassword(oldpass);
                        if (model.OldPassword.Trim() == oldpwd)
                        {
                            string newpass = BalajiVedic.BLL.Password.EncryptPassword(model.NewPassword);
                            Int64 _pstatus = _user.ChangePassword(model.iUserID, newpass);
                            if (_pstatus == 1)
                            {
                                TempData["message"] = "<li class=\"success closable\">Password changed successfully.</li>";
                            }
                            else
                            {
                                TempData["message"] = "<li class=\"error closable\">The current password is incorrect or the new password is invalid.</li>";
                            }
                        }
                        else
                        {
                            TempData["message"] = "<li class=\"error closable\">The current password is incorrect or the new password is invalid.</li>";
                        }
                    }
                    else
                    {
                        TempData["message"] = "<li class=\"error closable\">The current password is incorrect or the new password is invalid.</li>";
                    }
                }
                return new RedirectResult(model.returnurl);
            }
            catch
            {
                TempData["message"] = "<li class=\"error closable\">Failed transaction.</li>";
                return new RedirectResult(model.returnurl);
            }
        }

       

        [Areas.Admin.Models.SessionClass.SessionExpireFilter]
        public ActionResult Profile()
        {
            try
            {
                int _qstatus = 0;
                Entities.Users _objuser = _user.GetUsersListBysUserId(HttpContext.User.Identity.Name.ToString(), ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objuser = _objuser;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
            }

            return View();
        }

    
        #endregion

   
        [HttpPost]
        public JsonResult CheckProfileEmailAvailability(Int64 iUserID, string Email)
        {
            try
            {
                int _status = 0;
                Entities.Users objEuser = _user.GetUsersListBysUserId(Email, ref _status);
                bool data = (objEuser.iUserID == iUserID || objEuser.iUserID == 0 ? true : false);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch 
            {
                return Json(new { ok = false, message = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>" });
            }
        }

        #region CAPTCHA

        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }

        [HttpPost]
        public JsonResult GetCaptcha()
        {
            try
            {
                string str = HttpContext.Session["captchastring"].ToString();

                return Json(new { ok = true, data = str, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message ="<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>" });
            }
        }

        #endregion
    }
}
