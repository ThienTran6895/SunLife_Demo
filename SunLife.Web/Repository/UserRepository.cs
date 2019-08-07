using Dapper;
using SunLife.Web.DAL;
using SunLife.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SunLife.Web.Repository
{
    public class UserRepository
    {
        public IEnumerable<User> GetAllUser(string UserName, string Email, DateTime LockoutEndDateUtc)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@UserName", UserName, DbType.String);
                if (LockoutEndDateUtc != DateTime.MinValue)
                    param.Add("@LockoutEndDateUtc", LockoutEndDateUtc, DbType.DateTime);
                param.Add("@Email", Email, DbType.String);
                var enumResult = DapperHelper.Query<User>("insurance_GetAllUser", "admin", param);
                return enumResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}