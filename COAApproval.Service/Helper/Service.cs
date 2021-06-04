using COAApproval.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace COAApproval.Service
{
    public class Service
    {
        public static HttpResponseMessage Process<T>(ProcessResult<T> Result, HttpRequestMessage Request)
        {
            switch (Result.Status)
            {
                case ProcessResultType.Success:
                    return Request.CreateResponse<T>(HttpStatusCode.OK, Result.Data);
                case ProcessResultType.UnAuthorize:
                    return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Unauthorized");
                default:
                    return Request.CreateResponse<string>(HttpStatusCode.BadRequest, Result.Message);
            }
        }
    }
}