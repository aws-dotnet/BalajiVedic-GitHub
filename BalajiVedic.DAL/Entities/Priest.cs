using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
   public class Priest
    {
        public Int64 RId { get; set; }
        public Int64 iPriestId { get; set; }
        public string sPriestName { get; set; }
        public bool bActive { get; set; }
        public string sCreateUser { get; set; }
        public DateTime dCreateDate { get; set; }
        public string sUpdateUser { get; set; }
        public DateTime dUpdateDate { get; set; }
       
    }
}
