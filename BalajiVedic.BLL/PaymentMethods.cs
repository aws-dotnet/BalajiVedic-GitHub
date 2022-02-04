using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BalajiVedic.BLL
{
  public  class PaymentMethods
    {
        DAL.PaymentMethods _PaymentMethods = new DAL.PaymentMethods();

        public List<Entities.PaymentMethods> GetPaymentMethodsList(ref int status)
        {
            List<Entities.PaymentMethods> lstPaymentMethods = new List<Entities.PaymentMethods>();
            DataTable dt = _PaymentMethods.GetPaymentMethodsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.PaymentMethods objPaymentMethods = new Entities.PaymentMethods();

                    objPaymentMethods.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objPaymentMethods.iPaymentMethodID = (dr["iPaymentMethodID"] != DBNull.Value ? Convert.ToInt64(dr["iPaymentMethodID"]) : 0);



                    lstPaymentMethods.Add(objPaymentMethods);
                }

            }
            return lstPaymentMethods;
        }

        public List<Entities.PaymentMethods> GetPaymentMethodsListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.PaymentMethods> lstPaymentMethods = new List<Entities.PaymentMethods>();
            DataTable dt = _PaymentMethods.GetPaymentMethodsListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.PaymentMethods objPaymentMethods = new Entities.PaymentMethods();

                    objPaymentMethods.RId = Convert.ToInt32(dr["RId"].ToString());
                    objPaymentMethods.sPaymentMethod = (dr["sPaymentMethod"] != DBNull.Value ? dr["sPaymentMethod"].ToString() : "");
                    objPaymentMethods.iPaymentMethodID = (dr["iPaymentMethodID"] != DBNull.Value ? Convert.ToInt64(dr["iPaymentMethodID"]) : 0);
                    objPaymentMethods.sLastUpdateUser = (dr["sLastUpdateUser"] != DBNull.Value ? dr["sLastUpdateUser"].ToString() : "");

                    
                    lstPaymentMethods.Add(objPaymentMethods);
                }
            }
            return lstPaymentMethods;
        }

    }
}
