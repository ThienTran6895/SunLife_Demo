using Dapper;
using SunLife.Web.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SunLife.Web.Models;

namespace SunLife.Web.Repository
{
    public class FileRepository
    {
        public int AddFile(SunLifeFileModels file)
        {
            try
            {
                var param = new DynamicParameters();
                if (file.FileID != Guid.Empty)
                    param.Add("@FileID", file.FileID, DbType.Guid);
                else
                    param.Add("@FileID", Guid.NewGuid(), DbType.Guid);

                param.Add("@FileName", file.FileName, DbType.String);
                param.Add("@UploadPerson", file.UploadPerson, DbType.String);
                var enumResult = DapperHelper.Execute("insurance_AddFile", "admin", param);

                return enumResult;
            }
            catch (Exception ex)
            {
                // ghi log
                throw ex;
            }
        }

        public IEnumerable<SunLifeFileModels> GetAllFile(string FileName, DateTime UploadDate)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FileName", FileName, DbType.String);
                if (UploadDate != DateTime.MinValue)
                    param.Add("@UploadDate", UploadDate, DbType.DateTime);

                var enumResult = DapperHelper.Query<SunLifeFileModels>("insurance_GetAllFile", "admin", param);
                return enumResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
      

        public int DeleteFile(string FileName)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FileName", FileName, DbType.String);
                var enumResult = DapperHelper.Execute("uploadfile_DeleteFile", "admin", param);
                return enumResult;
            }
            catch (Exception ex)
            {
                // ghi log
                throw ex;
            }
        }
    }
}