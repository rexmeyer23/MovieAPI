using Film.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmAPI.Controllers
{
    [Authorize]
    public class AdminController : ApiController
    {

        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateAdminService();
        //    if (!service.RemoveProfile(id))
        //        return InternalServerError();

        //    return Ok();
        //}

        private AdminService CreateAdminService()
        {
            var profileId = Guid.Parse(User.Identity.GetUserId());
            var adminService = new AdminService(profileId);
            return adminService;
        }
    }
}
