using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
  public  class DonorType
    {
        #region DonorType 
        //kiran
        DAL.DonorType _DonorType = new DAL.DonorType();

        public Int64 InsertDonorType(Entities.DonorType objDonorType)
        {
            Int64 _status = 0;
            if (objDonorType != null)
            {
                _status = _DonorType.InsertDonorType(objDonorType);

            }
            return _status;
        }

        public Int64 DeleteDonorType(Int64 iDonorTypeID)
        {
            Int64 _status = 0;
            _status = _DonorType.DeleteDonorType(iDonorTypeID);
            return _status;
        }

        public Int64 UpdateDonorTypeStatus(Int64 iUserID)
        {
            Int64 _status = 0;
            _status = _DonorType.UpdateDonorTypeStatus(iUserID);
            return _status;
        }

        public List<Entities.DonorType> GetDonorTypeListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.DonorType> lstDonorType = new List<Entities.DonorType>();
            DataTable dt = _DonorType.GetDonorTypeListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.DonorType objlstDonorType = new Entities.DonorType();

                    objlstDonorType.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstDonorType.iDonorTypeID = Convert.ToInt32(dr["iDonorTypeID"].ToString());
                    objlstDonorType.sDonorType = (dr["sDonorType"] != DBNull.Value ? dr["sDonorType"].ToString() : "");
                    objlstDonorType.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                    objlstDonorType.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objlstDonorType.dCreateDate = (dr["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateDate"]) : DateTime.MinValue);
                    objlstDonorType.sLastUpdateUser = (dr["sLastUpdateUser"] != DBNull.Value ? dr["sLastUpdateUser"].ToString() : "");
                    objlstDonorType.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);


                    lstDonorType.Add(objlstDonorType);
                }
            }
            return lstDonorType;
        }

        public List<Entities.DonorType> GetDonorTypeList(ref int status)
        {
            List<Entities.DonorType> lstDonorType = new List<Entities.DonorType>();
            DataTable dt = _DonorType.GetDonorTypeList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.DonorType objlstDonorType = new Entities.DonorType();

                    objlstDonorType.iDonorTypeID = Convert.ToInt32(dr["iDonorTypeID"].ToString());
                    objlstDonorType.sDonorType = (dr["sDonorType"] != DBNull.Value ? dr["sDonorType"].ToString() : "");
                    objlstDonorType.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                    objlstDonorType.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objlstDonorType.dCreateDate = (dr["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateDate"]) : DateTime.MinValue);
                    objlstDonorType.sLastUpdateUser = (dr["sLastUpdateUser"] != DBNull.Value ? dr["sLastUpdateUser"].ToString() : "");
                    objlstDonorType.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);

                    lstDonorType.Add(objlstDonorType);
                }

            }
            return lstDonorType;
        }

        public Entities.DonorType GetCountrysById(Int64 iDonorTypeID, ref int status)
        {
            Entities.DonorType objDonorType = new Entities.DonorType();
            DataTable dt = new DataTable();
            if (iDonorTypeID != 0)
            {
                dt = _DonorType.GetDonorTypeListById(iDonorTypeID, ref status);
                if (dt.Rows.Count == 1)
                {
                    objDonorType.iDonorTypeID = Convert.ToInt32(dt.Rows[0]["iDonorTypeID"].ToString());
                    objDonorType.sDonorType = dt.Rows[0]["sDonorType"].ToString();
                  

                }
            }
            return objDonorType;
        }


        

        #endregion


    }
}
