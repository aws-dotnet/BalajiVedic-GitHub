using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
 public   class DonationType
    {

        #region DonationType 
        //kiran
        DAL.DonationType _DonationType = new DAL.DonationType();

        public Int64 InsertDonationType(Entities.DonationType objDonorType)
        {
            Int64 _status = 0;
            if (objDonorType != null)
            {
                _status = _DonationType.InsertDonationType(objDonorType);

            }
            return _status;
        }


        public Int64 DonationTypeNotesUpdate(Entities.DonationType objDonorType)
        {
            Int64 _status = 0;
            if (objDonorType != null)
            {
                _status = _DonationType.DonationTypeNotesUpdate(objDonorType);

            }
            return _status;
        }


        public Int64 DonationTypeDelete(Int64 iDonationTypeID)
        {
            Int64 _status = 0;
            _status = _DonationType.DonationTypeDelete(iDonationTypeID);
            return _status;
        }

        public Int64 UpdateDonationTypeStatus(Int64 iUserID)
        {
            Int64 _status = 0;
            _status = _DonationType.UpdateDonationTypeStatus(iUserID);
            return _status;
        }

        public List<Entities.DonationType> GetDonationTypeListByVariable(string ddlType, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.DonationType> lstDonorType = new List<Entities.DonationType>();
            DataTable dt = _DonationType.GetDonationTypeListByVariable(ddlType, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.DonationType objlstDonorType = new Entities.DonationType();

                    objlstDonorType.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonorType.iDonationTypeID = Convert.ToInt32(dr["iDonationTypeID"].ToString());
                    objlstDonorType.sDonationTypeDesc = (dr["sDonationTypeDesc"] != DBNull.Value ? dr["sDonationTypeDesc"].ToString() : "");
                    objlstDonorType.fPrice = (dr["fPrice"] != DBNull.Value ? Convert.ToDouble(dr["fPrice"]) : 0);
                    objlstDonorType.sDonationType = (dr["sDonationType"] != DBNull.Value ? dr["sDonationType"].ToString() : "");
                    objlstDonorType.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                    objlstDonorType.bTaxDeductible = (dr["bTaxDeductible"] != DBNull.Value ? Convert.ToBoolean(dr["bTaxDeductible"]) : false);
                    objlstDonorType.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objlstDonorType.dCreateUser = (dr["dCreateUser"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateUser"]) : DateTime.MinValue);
                    objlstDonorType.sLastUpdateUser = (dr["sLastUpdateUser"] != DBNull.Value ? dr["sLastUpdateUser"].ToString() : "");
                    objlstDonorType.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);
                    objlstDonorType.sPoojaFrequency = (dr["sPoojaFrequency"] != DBNull.Value ? dr["sPoojaFrequency"].ToString() : "");
                    objlstDonorType.sNotes = (dr["sNotes"] != DBNull.Value ? dr["sNotes"].ToString() : "");
                    objlstDonorType.sPriestCommissionBased = (dr["sPriestCommissionBased"] != DBNull.Value ? dr["sPriestCommissionBased"].ToString() : "");
                    objlstDonorType.fPriestCommision = (dr["fPriestCommision"] != DBNull.Value ? Convert.ToDouble(dr["fPriestCommision"]) : 0);
                    objlstDonorType.CommissionType = (dr["CommissionType"] != DBNull.Value ? dr["CommissionType"].ToString() : "");


                    lstDonorType.Add(objlstDonorType);
                }
            }
            return lstDonorType;
        }

        public List<Entities.DonationType> GetPoojaDonationsListByVariable(string sFrequency, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.DonationType> lstDonationType = new List<Entities.DonationType>();
            DataTable dt = _DonationType.GetPoojaDonationsListByVariable(sFrequency, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.DonationType objlstDonorType = new Entities.DonationType();

                    objlstDonorType.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonorType.iDonationTypeID = Convert.ToInt32(dr["iDonationTypeId"].ToString());
                    objlstDonorType.sDonorType = (dr["sDonorType"] != DBNull.Value ? dr["sDonorType"].ToString() : "");
                    objlstDonorType.sDonationTypeDesc = (dr["sDonationTypeDesc"] != DBNull.Value ? dr["sDonationTypeDesc"].ToString() : "");
                    objlstDonorType.fPrice = (dr["fPrice"] != DBNull.Value ? Convert.ToDouble(dr["fPrice"]) : 0);
                    objlstDonorType.sNotes = (dr["sNotes"] != DBNull.Value ? dr["sNotes"].ToString() : "");


                    lstDonationType.Add(objlstDonorType);
                }
            }
            return lstDonationType;
        }


        public List<Entities.DonationType> GetDonationTypeList(ref int status)
        {
            List<Entities.DonationType> lstDonorType = new List<Entities.DonationType>();
            DataTable dt = _DonationType.GetDonationTypeList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.DonationType objlstDonorType = new Entities.DonationType();

                    objlstDonorType.iDonationTypeID = Convert.ToInt32(dr["iDonationTypeID"].ToString());
                    objlstDonorType.sPoojaFrequency = (dr["sPoojaFrequency"] != DBNull.Value ? dr["sPoojaFrequency"].ToString() : "");
                    objlstDonorType.sDonationTypeDesc = (dr["sDonationTypeDesc"] != DBNull.Value ? dr["sDonationTypeDesc"].ToString() : "");

                    lstDonorType.Add(objlstDonorType);
                }

            }
            return lstDonorType;
        }

        public Entities.DonationType GetDonationTypeListById(Int64 iDonationTypeID, ref int status)
        {
            Entities.DonationType objDonorType = new Entities.DonationType();
            DataTable dt = new DataTable();
            if (iDonationTypeID != 0)
            {
                dt = _DonationType.GetDonationTypeListById(iDonationTypeID, ref status);
                if (dt.Rows.Count == 1)
                {
                   
                    objDonorType.iDonationTypeID = Convert.ToInt32(dt.Rows[0]["iDonationTypeID"].ToString());
                    objDonorType.sDonationTypeDesc = (dt.Rows[0]["sDonationTypeDesc"] != DBNull.Value ? dt.Rows[0]["sDonationTypeDesc"].ToString() : "");
                    objDonorType.fPrice = (dt.Rows[0]["fPrice"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["fPrice"]) : 0);
                    objDonorType.sDonationType = (dt.Rows[0]["sDonationType"] != DBNull.Value ? dt.Rows[0]["sDonationType"].ToString() : "");
                    objDonorType.bActive = (dt.Rows[0]["bActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bActive"]) : false);
                    objDonorType.bTaxDeductible = (dt.Rows[0]["bTaxDeductible"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bTaxDeductible"]) : false);
                    objDonorType.sCreateUser = (dt.Rows[0]["sCreateUser"] != DBNull.Value ? dt.Rows[0]["sCreateUser"].ToString() : "");
                    objDonorType.dCreateUser = (dt.Rows[0]["dCreateUser"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dCreateUser"]) : DateTime.MinValue);
                    objDonorType.sLastUpdateUser = (dt.Rows[0]["sLastUpdateUser"] != DBNull.Value ? dt.Rows[0]["sLastUpdateUser"].ToString() : "");
                    objDonorType.dLastUpdateDate = (dt.Rows[0]["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dLastUpdateDate"]) : DateTime.MinValue);
                    objDonorType.sPoojaFrequency = (dt.Rows[0]["sPoojaFrequency"] != DBNull.Value ? dt.Rows[0]["sPoojaFrequency"].ToString() : "");
                    objDonorType.sNotes = (dt.Rows[0]["sNotes"] != DBNull.Value ? dt.Rows[0]["sNotes"].ToString() : "");
                    objDonorType.sPriestCommissionBased = (dt.Rows[0]["sPriestCommissionBased"] != DBNull.Value ? dt.Rows[0]["sPriestCommissionBased"].ToString() : "");
                    objDonorType.fPriestCommision = (dt.Rows[0]["fPriestCommision"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["fPriestCommision"]) : 0);
       
                }
            }
            return objDonorType;
        }




        #endregion


    }
}
