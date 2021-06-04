using COAApproval.Repository.Model;
using COAApproval.Repository.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COAApproval.Service.Controllers
{
    public class ApprovalController : ApiController
    {
        ApprovalRepo repo = new ApprovalRepo();

        [AcceptVerbs("GET")]
        [Route("api/approval")]
        public HttpResponseMessage Getapproval()
        {
            return Service.Process<List<COA_Approval>>(repo.GetAllapproval(), Request);
        }
         

        [AcceptVerbs("GET")]
        [Route("api/approvalID/{id}")]
        public HttpResponseMessage GetapprovalByID(int id)
        {
            return Service.Process<List<COA_Approval>>(repo.GetApprovalByID(id), Request);
        }

        [AcceptVerbs("GET")]
        [Route("api/approvalbyPICID/{id}")]
        public HttpResponseMessage GetapprovalByPICID(int id)
        {
            return Service.Process<List<COA_Approval>>(repo.GetApprovalByPICID(id), Request);
        }









        [AcceptVerbs("POST")]
        [Route("api/approval/Add")]
        public HttpResponseMessage Addapproval(SurveyorInput input)
        {
            return Service.Process<List<SurveyorInput>>(repo.Addapproval(input), Request);
        }

        [AcceptVerbs("POST")]
        [Route("api/approval/Atasan")]
        public HttpResponseMessage Addapproval(ApprovalAtasan input)
        {
            return Service.Process<List<ApprovalAtasan>>(repo.ApprovalAtasan(input), Request);
        }

        //[AcceptVerbs("POST")]
        //[Route("api/approval/Update")]
        //public HttpResponseMessage Updateapproval(COA_Approval input)
        //{
        //    return Service.Process<List<COA_Approval>>(repo.Updateapproval(input), Request);
        //}

        //[AcceptVerbs("POST")]
        //[Route("api/approval/Delete")]
        //public HttpResponseMessage Deleteapproval(COA_Approval input)
        //{
        //    return Service.Process<List<COA_Approval>>(repo.Deleteapproval(input), Request);
        //}

    }

}
