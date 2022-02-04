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
        List<Entities.State> lstStates = new List<Entities.State>();



        #region HomePage Donors
        public ActionResult HomePageDonors(string sLastName = "", string sFirstName = "", Int64 iDonorId = 0, string sPhoneNumber = "")
        {
            int status = 0;
            lstDonorType = _DonorType.GetDonorTypeList(ref status);
            lstStates = _Donors.GetStateList(ref status);

            ViewBag.lstStates = lstStates;
            ViewBag.lstDonorType = lstDonorType;
            ViewBag.sLastName = sLastName;
            ViewBag.sFirstName = sFirstName;
            ViewBag.iDonorId = iDonorId;
            ViewBag.sPhoneNumber = sPhoneNumber;

            return View();
        }


        public ActionResult HomePageDonorsList(string sLastName = "", string sFirstName = "", string dDateOfJoin = "", Int64 iDonorTypeID = 0, Int64 iDonorId = 0, string sPhoneNumber = "", string sSpouseLastName = "", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donors.GetDonorsListByVariable(sLastName, sFirstName, dDateOfJoin, iDonorTypeID, iDonorId, sPhoneNumber, sSpouseLastName, Search, Sort, PageNo, Items, ref Total);
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



        #endregion

        #region Donors

        public ActionResult Index()
        {
            int status = 0;
            lstDonorType = _DonorType.GetDonorTypeList(ref status);
            lstStates = _Donors.GetStateList(ref status);

            ViewBag.lstStates = lstStates;
            ViewBag.lstDonorType = lstDonorType;
            return View();
        }


        public ActionResult DonorsList(string sLastName = "", string sFirstName = "", string dDateOfJoin = "",Int64 iDonorTypeID=0,Int64 iDonorId=0,string sPhoneNumber="",string sSpouseLastName="", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donors.GetDonorsListByVariable(sLastName, sFirstName, dDateOfJoin, iDonorTypeID, iDonorId, sPhoneNumber, sSpouseLastName, Search, Sort, PageNo, Items, ref Total);
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


        public ActionResult AddDonor()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DonorsInsert(Entities.Donors objDonors)
        {
            objDonors.sCreateUser = HttpContext.User.Identity.Name.ToString();
            objDonors.dCreateDate = DateTime.UtcNow;
            objDonors.dLastUpdateUser = HttpContext.User.Identity.Name.ToString();
            objDonors.dLastUpdateDate = DateTime.UtcNow;
            Int64 iDonorID = 0;
            try
            {
                Int64 _status = _Donors.DonorsInsert(objDonors, ref iDonorID);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Inserted Record.</div>";
                    return RedirectToAction("Index", "Donors");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Successfully Updated Record.</div>";
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

        public ActionResult EditDonor(Int64 iDonorId)
        {
            Entities.Donors objDonors = new Entities.Donors();

            int status = 0;

            try
            {
                int _qstatus = 0;
                objDonors = _Donors.GetDonorsListById(iDonorId, ref status);



            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Donors");
            }
            ViewBag.objDonors = objDonors;
            return View();
        }


        public ActionResult ViewDonor(Int64 iDonorId)
        {
            Entities.Donors objDonors = new Entities.Donors();

            int status = 0;

            try
            {
                int _qstatus = 0;
                objDonors = _Donors.GetDonorsListById(iDonorId, ref status);



            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Donors");
            }
            ViewBag.objDonors = objDonors;
            return View();
        }



        public ActionResult DonorDonations(Int64 iDonorId=0,string FirstName="",String LastName="")
        {
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            ViewBag.iDonorId = iDonorId;

            return View();
        }


        public ActionResult DonorDonationsList(Int64 iDonorId = 0,Int64 iYear=0, string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donors.GetDonorDonationsListByVariable(iDonorId, iYear, Search, Sort, PageNo, Items, ref Total);
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


   
        public void ExportToDonorDonationsByList(Int64 iDonorId=0, Int64 iYear=0, string Search = "", string SortColumn = "", string SortOrder = "")
        {
            try
            {
                BalajiVedic.DAL.Donors _DDonors = new BalajiVedic.DAL.Donors();
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DDonors.ExportToDonorDonationsByList(iDonorId, iYear, Search, Sort);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "DonorDonations-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=DonorDonations-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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

        #region Donors List Reports

        public ActionResult ReportsDonor()
        {
            int status = 0;
            lstDonorType = _DonorType.GetDonorTypeList(ref status);

            ViewBag.lstDonorType = lstDonorType;
            return View();
        }


        public ActionResult ReportsDonorList(Int64 iDonorTypeID=0,string StartDate ="",string EndDate="",string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
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

        

        public void ExportToReportsDonorList(Int64 iDonorTypeID=0,string StartDate = "", string EndDate = "", string Search = "",string SortColumn = "", string SortOrder = "")
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



        #region Donor List By Donation Report

        public ActionResult ReportsDonation()
        {
            int status = 0;
            lstDonorType = _DonorType.GetDonorTypeList(ref status);

            ViewBag.lstDonorType = lstDonorType;
            return View();
        }


        public ActionResult ReportsDonationList(string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 25)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donors.GetReportsDonorListByDonationListByVariable(StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
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



        public void ExportToReportsDonationList(string StartDate = "", string EndDate = "", string Search = "", string SortColumn = "", string SortOrder = "")
        {
            try
            {
                BalajiVedic.DAL.Donors _DDonors = new BalajiVedic.DAL.Donors();
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DDonors.ExportToReportsDonorListByDonationList(StartDate, EndDate, Search, Sort);
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Donations-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Donations-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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