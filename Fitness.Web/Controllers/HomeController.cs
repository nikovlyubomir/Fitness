using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fitness.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Fitness.Web.Data.Models;

namespace Fitness.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Workout()
        {
            return View(new WorkoutModel());
        }

        [HttpPost]
        public IActionResult Workout(WorkoutModel workout)
        {
            return Ok();
        }
    }
}
