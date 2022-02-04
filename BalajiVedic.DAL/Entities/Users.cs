using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalajiVedic.Entities
{
 public   class Users
    {
        public Int64 RId { get; set; }
        public Int64 iUserID { get; set; }
        public string sUserID { get; set; }
        public string sFirstName { get; set; }
        public string sLastName { get; set; }
        public string sPassword { get; set; }
        public Int64 iRoleID { get; set; }
        public string RoleName { get; set; }
        public bool bActive { get; set; }
        public string sEmail { get; set; }
        public bool iFailedLogins { get; set; }
        public bool bLockOut { get; set; }

        public string sRole { get; set; }
        public bool bForcePasswordChange { get; set; }
        public string sCreateUser { get; set; }
        public DateTime dCreateDate { get; set; }
        public string sLastUpdateUser { get; set; }
        public DateTime dLastUpdateDate { get; set; }
        public bool RememberMe { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string returnurl { get; set; }

        public string Captcha { get; set; }


    }
}
