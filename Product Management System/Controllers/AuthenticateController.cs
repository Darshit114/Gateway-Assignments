using Newtonsoft.Json;
using PMS.BLL;
using PMS.Entities;
using Product_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Product_Management_System.Controllers
{
    [RoutePrefix("api/v1/auth")]
    public class AuthenticateController : ApiController
    {
        private readonly IUserBLL _user;

        public AuthenticateController(IUserBLL user)
        {
            _user = user;
        }

        [Route("admin")]
        [HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public HttpResponseMessage AuthenticateAdmin(Object model)
        {
            var jsonString = model.ToString();
            UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(jsonString);

            UserEntity userEntity = new UserEntity();

            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            
            if (ModelState.IsValid && userEntity != null )
            {
                UserEntity res = _user.AuthenticateUser(userEntity);

                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, Admin = res });
                } 
            }
 
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error!!");
        }

    }
}
