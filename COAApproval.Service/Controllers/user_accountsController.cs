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
    public class user_accountsController : ApiController
    {
        UserRepo repo = new UserRepo();

        [AcceptVerbs("GET")]
        [Route("api/user_accounts")]
        public HttpResponseMessage Getuser_accounts()
        {
            return Service.Process<List<user_accounts>>(repo.GetAlluser_accounts(), Request);
            //return Service.Process<List<user_accounts>>(repo.Getuser_accounts(), Request);
        }

        [AcceptVerbs("POST")]
        [Route("api/login")]
        public HttpResponseMessage GetLogin(user_login input)
        {
            return Service.Process<List<user_accounts>>(repo.LoginCheck(input), Request);
        }

        [AcceptVerbs("GET")]
        [Route("api/user_accountsID/{id}")]
        public HttpResponseMessage Getuser_accountsByID(int id)
        {
            return Service.Process<List<user_accounts>>(repo.Getuser_accountsByID(id), Request);
        }

        [AcceptVerbs("GET")]
        [Route("api/user_accountsUsername/{username}")]
        public HttpResponseMessage Getuser_accountsIndividu(string username)
        {
            return Service.Process<List<user_accounts>>(repo.Getuser_accountsByUsername(username), Request);
        }

        //[AcceptVerbs("GET")]
        //[Route("api/login")]
        //public HttpResponseMessage Getuser_accountsCorporate()
        //{
        //    return Service.Process<List<user_accounts>>(repo.LoginCheck(), Request);
        //}

        [AcceptVerbs("POST")]
        [Route("api/user_accounts/Add")]
        public HttpResponseMessage Adduser_accounts(user_accounts input)
        {
            return Service.Process<List<user_accounts>>(repo.Adduser_accounts(input), Request);
        }

        [AcceptVerbs("POST")]
        [Route("api/user_accounts/Update")]
        public HttpResponseMessage Updateuser_accounts(user_accounts input)
        {
            return Service.Process<List<user_accounts>>(repo.Updateuser_accounts(input), Request);
        }

        [AcceptVerbs("POST")]
        [Route("api/user_accounts/Delete")]
        public HttpResponseMessage Deleteuser_accounts(user_accounts input)
        {
            return Service.Process<List<user_accounts>>(repo.Deleteuser_accounts(input), Request);
        }

    }

}
