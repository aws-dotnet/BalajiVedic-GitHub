using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BalajiVedic.DAL
{
  public  class Users
    {

        #region Users 
        //kiran
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 InsertUsers(Entities.Users objUsers)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {

                    new SqlParameter("@iUserID",objUsers.iUserID),
                    new SqlParameter("@sUserID",(objUsers.sUserID==null?(object)DBNull.Value:objUsers.sUserID)),
                    new SqlParameter("@sFirstName",(objUsers.sFirstName==null?(object)DBNull.Value:objUsers.sFirstName)),
                    new SqlParameter("@sLastName",(objUsers.sLastName==null?(object)DBNull.Value:objUsers.sLastName)),
                    new SqlParameter("@sPassword",(objUsers.sPassword==null?(object)DBNull.Value:objUsers.sPassword)),
                    new SqlParameter("@iRoleID",(objUsers.iRoleID == 0 ?DBNull.Value:(object)objUsers.iRoleID)),
                    new SqlParameter("@bActive",(objUsers.bActive == false ?DBNull.Value:(object)objUsers.bActive)),
                    new SqlParameter("@sEmail",(objUsers.sEmail==null?(object)DBNull.Value:objUsers.sEmail)),
                    new SqlParameter("@iFailedLogins",(objUsers.iFailedLogins == false ?DBNull.Value:(object)objUsers.iFailedLogins)),
                    new SqlParameter("@bLockOut",(objUsers.bLockOut == false ?DBNull.Value:(object)objUsers.bLockOut)),
                    new SqlParameter("@bForcePasswordChange",(objUsers.bForcePasswordChange == false ?DBNull.Value:(object)objUsers.bForcePasswordChange)),
                    new SqlParameter("@sCreateUser",objUsers.sCreateUser),
                    new SqlParameter("@dCreateDate",DateTime.Now),
                    new SqlParameter("@sLastUpdateUser",objUsers.sLastUpdateUser),
                    new SqlParameter("@dLastUpdateDate",DateTime.Now),
                    new SqlParameter("@QStatus",0)

                  };
                _sqlP[15].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("UserInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[15].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetUsersListByVariable_bkp(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {

                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("UserGetListByVariable_bkp", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public DataTable GetUsersListByVariable(string sUserID,string Name,Int64 iRoleID,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {

                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total),
                    new SqlParameter("@sUserID",sUserID),
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@iRoleID",iRoleID),

        
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("UserGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetUsersList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("UserGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetUsersListById(Int64 iUserID, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iUserID",iUserID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("UserGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetUsersListBysUserId(string sUserId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@sUserId",sUserId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("UserGetBysUserId", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetPassword(Int64 iUserID, ref int _QStatus)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] {
                new SqlParameter("@iUserID",iUserID),
                new SqlParameter("@QStatus",_QStatus)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;

                dt = _dbAccess.GetDataTable("UsersGetByPassword", ref _sqlP);
                _QStatus = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public Int64 ChangePassword(Int64 iUserID, string sPassword)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iUserID",iUserID),
                    new SqlParameter("@sPassword",sPassword),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("UsersChangePassword", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }



        public Int64 DeleteUser(Int64 iUserID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iUserID",iUserID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("UserDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 UpdateUsersStatus(Int64 iUserID)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@iUserID",iUserID),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("UserUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }



        #endregion

    }
}
