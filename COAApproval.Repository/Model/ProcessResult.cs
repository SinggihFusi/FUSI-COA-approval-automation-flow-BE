using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COAApproval.Repository.Model;
using COAApproval.Repository.Repositories;

namespace COAApproval.Repository.Model
{
    public enum ProcessResultType
    {
        Success = 1,
        UnAuthorize = 2,
        UnknownError = 3,
        DBError = 4
    }

    public class ProcessResult<T>
    {
        public string ProcessName { get; set; }
        public string ActionName { get; set; }
        public string UserName { get; set; }
        public ProcessResultType Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ProcessResult
    {
        //public static void Error<T>(ProcessResult<T> result, string message)
        //{
        //    //App.Log(result.ProcessName, message);
        //    result.Message = message;
        //    result.Status = ProcessResultType.UnknownError;
        //}
        //public static void Error<T>(ProcessResult<T> result, string message, ProcessResultType status)
        //{
        //    //App.Log(result.ProcessName, message);
        //    result.Message = message;
        //    result.Status = status;
        //}
        //public static void Success<T>(ProcessResult<T> result)
        //{
        //    //App.Log(result.ProcessName, data);
        //    result.Message = result.ProcessName + " success!";
        //    result.Status = ProcessResultType.Success;
        //}
        //public static void Error<T>(Model.ProcessResult<T> result, Exception ex)
        //{
        //    result.Message = ex.Message;
        //    if (ex.InnerException != null) result.Message += " :: " + ex.InnerException.Message;
        //    result.Status = ProcessResultType.UnknownError;
        //}

        //private static AuditRepository repoAudit = new AuditRepository();
        public static void Error<T>(ProcessResult<T> result, string message)
        {
            //App.Log(result.ProcessName, message);
            //ApplicationLogger.Error(result.ProcessName, message);

            result.Message = message;
            result.Status = ProcessResultType.UnknownError;
        }
        public static void Error<T>(ProcessResult<T> result, string message, ProcessResultType status)
        {
            //repoAudit.AddAudit(result.ProcessName, result.ActionName, "Error " + result.UserName, Newtonsoft.Json.JsonConvert.SerializeObject(result.Data));
            //ApplicationLogger.Error(result.ProcessName, message);

            result.Message = message;
            result.Status = status;
        }
        public static void Success<T>(ProcessResult<T> result)
        {
            if (result.ProcessName.Contains(".AddLog"))
            {
                result.ProcessName = result.ProcessName.Split('.')[0];

                //repoAudit.AddAudit(result.ProcessName, result.ActionName, result.UserName, Newtonsoft.Json.JsonConvert.SerializeObject(result.Data));
            }
            result.Message = result.ProcessName + " success!";
            result.Status = ProcessResultType.Success;
        }
        public static void Error<T>(Model.ProcessResult<T> result, Exception ex)
        {
            result.Message = ex.Message;
            if (ex.InnerException != null)
            {
                result.Message += " :: " + ex.InnerException.Message;
            }
            else
            {
                result.Message += " :: " + ex.StackTrace;
            }

            result.Status = ProcessResultType.UnknownError;

            //ApplicationLogger.Error(result.ProcessName, result.Message);
        }
    }
}
