using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BalajiVedic.BLL
{
  public  class Users
    {
        #region Users 
        //kiran
        DAL.Users _Users = new DAL.Users();

        public Int64 InsertUsers(Entities.Users objUsers)
        {
            Int64 _status = 0;
            if (objUsers != null)
            {
                _status = _Users.InsertUsers(objUsers);

            }
            return _status;
        }

        public Int64 DeleteUsers(Int64 iUserID)
        {
            Int64 _status = 0;
            _status = _Users.DeleteUser(iUserID);
            return _status;
        }

        public Int64 UpdateUsersStatus(Int64 iUserID)
        {
            Int64 _status = 0;
            _status = _Users.UpdateUsersStatus(iUserID);
            return _status;
        }

        public string GetPassword(Int64 iUserID, ref int _qstatus)
        {
            string _password = "";
            DataTable dt = _Users.GetPassword(iUserID, ref _qstatus);
            if (dt.Rows.Count == 1)
            {
                _password = dt.Rows[0]["sPassword"].ToString();
            }
            return _password;
        }


        public Int64 ChangePassword(Int64 iUserID, string sPassword)
        {
            Int64 _status = 0;
            if (iUserID != 0 && sPassword != null && sPassword.Trim() != "")
            {
                _status = _Users.ChangePassword(iUserID, sPassword);
            }
            return _status;
        }


        public List<Entities.Users> GetUsersListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<Entities.Users> lstUsers = new List<Entities.Users>();
            DataTable dt = _Users.GetUsersListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Users objlstUsers = new Entities.Users();

                    objlstUsers.RId = Convert.ToInt32(dr["RId"].ToString());
                    objlstUsers.iUserID = Convert.ToInt32(dr["iUserID"].ToString());
                    objlstUsers.sUserID = (dr["sUserID"] != DBNull.Value ? dr["sUserID"].ToString() : "");
                    objlstUsers.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objlstUsers.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");
                    objlstUsers.sPassword = (dr["sPassword"] != DBNull.Value ? dr["sPassword"].ToString() : "");
                    objlstUsers.iRoleID = (dr["iRoleID"] != DBNull.Value ? Convert.ToInt64(dr["iRoleID"]) : 0);
                    objlstUsers.bActive = (dr["bActive"] != DBNull.Value ? Convert.ToBoolean(dr["bActive"]) : false);
                    objlstUsers.sEmail = (dr["sEmail"] != DBNull.Value ? dr["sEmail"].ToString() : "");
                    objlstUsers.iFailedLogins = (dr["iFailedLogins"] != DBNull.Value ? Convert.ToBoolean(dr["iFailedLogins"]) : false);
                    objlstUsers.bLockOut = (dr["bLockOut"] != DBNull.Value ? Convert.ToBoolean(dr["bLockOut"]) : false);
                    objlstUsers.bForcePasswordChange = (dr["bForcePasswordChange"] != DBNull.Value ? Convert.ToBoolean(dr["bForcePasswordChange"]) : false);
                    objlstUsers.sCreateUser = (dr["sCreateUser"] != DBNull.Value ? dr["sCreateUser"].ToString() : "");
                    objlstUsers.dCreateDate = (dr["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dCreateDate"]) : DateTime.MinValue);
                    objlstUsers.sLastUpdateUser = (dr["sLastUpdateUser"] != DBNull.Value ? dr["sLastUpdateUser"].ToString() : "");
                    objlstUsers.dLastUpdateDate = (dr["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dr["dLastUpdateDate"]) : DateTime.MinValue);
                    objlstUsers.RoleName = (dr["RoleName"] != DBNull.Value ? dr["RoleName"].ToString() : "");



                    lstUsers.Add(objlstUsers);
                }
            }
            return lstUsers;
        }

        public List<Entities.Users> GetUsersList(ref int status)
        {
            List<Entities.Users> lstUsers = new List<Entities.Users>();
            DataTable dt = _Users.GetUsersList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Users objlstUsers = new Entities.Users();

                    objlstUsers.iUserID = Convert.ToInt32(dr["iUserID"].ToString());
                    objlstUsers.sUserID = (dr["sUserID"] != DBNull.Value ? dr["sUserID"].ToString() : "");
                    objlstUsers.sFirstName = (dr["sFirstName"] != DBNull.Value ? dr["sFirstName"].ToString() : "");
                    objlstUsers.sLastName = (dr["sLastName"] != DBNull.Value ? dr["sLastName"].ToString() : "");

                    lstUsers.Add(objlstUsers);
                }

            }
            return lstUsers;
        }

        public Entities.Users GetUsersListById(Int64 iUserID, ref int status)
        {
            Entities.Users objUsers = new Entities.Users();
            DataTable dt = new DataTable();
            if (iUserID != 0)
            {
                dt = _Users.GetUsersListById(iUserID, ref status);
                if (dt.Rows.Count == 1)
                {
                   
                    objUsers.iUserID = Convert.ToInt32(dt.Rows[0]["iUserID"].ToString());
                    objUsers.sUserID = (dt.Rows[0]["sUserID"] != DBNull.Value ? dt.Rows[0]["sUserID"].ToString() : "");
                    objUsers.sFirstName = (dt.Rows[0]["sFirstName"] != DBNull.Value ? dt.Rows[0]["sFirstName"].ToString() : "");
                    objUsers.sLastName = (dt.Rows[0]["sLastName"] != DBNull.Value ? dt.Rows[0]["sLastName"].ToString() : "");
                    objUsers.sPassword = (dt.Rows[0]["sPassword"] != DBNull.Value ? dt.Rows[0]["sPassword"].ToString() : "");
                    objUsers.iRoleID = (dt.Rows[0]["iRoleID"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iRoleID"]) : 0);
                    objUsers.bActive = (dt.Rows[0]["bActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bActive"]) : false);
                    objUsers.sEmail = (dt.Rows[0]["sEmail"] != DBNull.Value ? dt.Rows[0]["sEmail"].ToString() : "");
                    objUsers.iFailedLogins = (dt.Rows[0]["iFailedLogins"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["iFailedLogins"]) : false);
                    objUsers.bLockOut = (dt.Rows[0]["bLockOut"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bLockOut"]) : false);
                    objUsers.bForcePasswordChange = (dt.Rows[0]["bForcePasswordChange"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bForcePasswordChange"]) : false);
                    objUsers.sCreateUser = (dt.Rows[0]["sCreateUser"] != DBNull.Value ? dt.Rows[0]["sCreateUser"].ToString() : "");
                    objUsers.dCreateDate = (dt.Rows[0]["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dCreateDate"]) : DateTime.MinValue);
                    objUsers.sLastUpdateUser = (dt.Rows[0]["sLastUpdateUser"] != DBNull.Value ? dt.Rows[0]["sLastUpdateUser"].ToString() : "");
                    objUsers.dLastUpdateDate = (dt.Rows[0]["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dLastUpdateDate"]) : DateTime.MinValue);
                    objUsers.RoleName = (dt.Rows[0]["RoleName"] != DBNull.Value ? dt.Rows[0]["RoleName"].ToString() : "");


                }
            }
            return objUsers;
        }


        public Entities.Users GetUsersListBysUserId(string sUserID, ref int status)
        {
            Entities.Users objUsers = new Entities.Users();
            DataTable dt = new DataTable();
            if (sUserID != "")
            {
                dt = _Users.GetUsersListBysUserId(sUserID, ref status);
                if (dt.Rows.Count == 1)
                {

                    objUsers.iUserID = Convert.ToInt32(dt.Rows[0]["iUserID"].ToString());
                    objUsers.sUserID = (dt.Rows[0]["sUserID"] != DBNull.Value ? dt.Rows[0]["sUserID"].ToString() : "");
                    objUsers.sFirstName = (dt.Rows[0]["sFirstName"] != DBNull.Value ? dt.Rows[0]["sFirstName"].ToString() : "");
                    objUsers.sLastName = (dt.Rows[0]["sLastName"] != DBNull.Value ? dt.Rows[0]["sLastName"].ToString() : "");
                    objUsers.sPassword = (dt.Rows[0]["sPassword"] != DBNull.Value ? dt.Rows[0]["sPassword"].ToString() : "");
                    objUsers.iRoleID = (dt.Rows[0]["iRoleID"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["iRoleID"]) : 0);
                    objUsers.bActive = (dt.Rows[0]["bActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bActive"]) : false);
                    objUsers.sEmail = (dt.Rows[0]["sEmail"] != DBNull.Value ? dt.Rows[0]["sEmail"].ToString() : "");
                    objUsers.iFailedLogins = (dt.Rows[0]["iFailedLogins"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["iFailedLogins"]) : false);
                    objUsers.bLockOut = (dt.Rows[0]["bLockOut"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bLockOut"]) : false);
                    objUsers.bForcePasswordChange = (dt.Rows[0]["bForcePasswordChange"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["bForcePasswordChange"]) : false);
                    objUsers.sCreateUser = (dt.Rows[0]["sCreateUser"] != DBNull.Value ? dt.Rows[0]["sCreateUser"].ToString() : "");
                    objUsers.dCreateDate = (dt.Rows[0]["dCreateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dCreateDate"]) : DateTime.MinValue);
                    objUsers.sLastUpdateUser = (dt.Rows[0]["sLastUpdateUser"] != DBNull.Value ? dt.Rows[0]["sLastUpdateUser"].ToString() : "");
                    objUsers.dLastUpdateDate = (dt.Rows[0]["dLastUpdateDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["dLastUpdateDate"]) : DateTime.MinValue);
                    objUsers.RoleName = (dt.Rows[0]["RoleName"] != DBNull.Value ? dt.Rows[0]["RoleName"].ToString() : "");


                }
            }
            return objUsers;
        }



        #endregion

    }
}
