using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
  public  class Priest
    {

        #region Priest 
        //kiran
        DAL.Priest _Priest = new DAL.Priest();

        public Int64 InsertPriest(Entities.Priest objPriest)
        {
            Int64 _status = 0;
            if (objPriest != null)
            {
                _status = _Priest.PriestInsert(objPriest);

            }
            return _status;
        }

        public Int64 DeletePriest(Int64 iPriestId)
        {
            Int64 _status = 0;
            _status = _Priest.DeletePriest(iPriestId);
            return _status;
        }

        public Int64 UpdatePriestStatus(Int64 iPriestId)
        {
            Int64 _status = 0;
            _status = _Priest.UpdatePriestStatus(iPriestId);
            return _status;
        }

        public List<Entities.Priest> GetPriestListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Priest> lstPriest = new List<Entities.Priest>();
            DataTable dt = _Priest.GetPriestListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Priest objlstPriest = new Entities.Priest();

                    objlstPriest.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstPriest.iPriestId = Convert.ToInt32(dr["iPriestId"].ToString());
                    objlstPriest.sPriestName = (dr["sPriestName"] != DBNull.Value ? dr["sPriestName"].ToString() : "");
                    objlstPriest.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                  

                    lstPriest.Add(objlstPriest);
                }
            }
            return lstPriest;
        }

        public List<Entities.Priest> GetPriestList(ref int status)
        {
            List<Entities.Priest> lstPriest = new List<Entities.Priest>();
            DataTable dt = _Priest.GetPriestList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Priest objlstPriest = new Entities.Priest();

                    objlstPriest.iPriestId = Convert.ToInt32(dr["iPriestId"].ToString());
                    objlstPriest.sPriestName = (dr["sPriestName"] != DBNull.Value ? dr["sPriestName"].ToString() : "");

                    lstPriest.Add(objlstPriest);
                }

            }
            return lstPriest;
        }

        public Entities.Priest GetPriestListById(Int64 iPriestId, ref int status)
        {
            Entities.Priest objPriest = new Entities.Priest();
            DataTable dt = new DataTable();
            if (iPriestId != 0)
            {
                dt = _Priest.GetPriestListById(iPriestId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objPriest.iPriestId = Convert.ToInt32(dt.Rows[0]["iPriestId"].ToString());
                    objPriest.sPriestName = (dt.Rows[0]["sPriestName"] != DBNull.Value ? dt.Rows[0]["sPriestName"].ToString() : "");
                    objPriest.bActive = (dt.Rows[0]["bActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bActive"]) : false);
                    objPriest.sCreateUser = (dt.Rows[0]["sCreateUser"] != DBNull.Value ? dt.Rows[0]["sCreateUser"].ToString() : "");
                    objPriest.dCreateDate = (dt.Rows[0]["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dCreateDate"]) : DateTime.MinValue);
                    objPriest.sUpdateUser = (dt.Rows[0]["sUpdateUser"] != DBNull.Value ? dt.Rows[0]["sUpdateUser"].ToString() : "");
                    objPriest.dUpdateDate = (dt.Rows[0]["dUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dUpdateDate"]) : DateTime.MinValue);

                }
            }
            return objPriest;
        }




        #endregion
    }
}
