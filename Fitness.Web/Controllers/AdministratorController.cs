using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdministratorController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}