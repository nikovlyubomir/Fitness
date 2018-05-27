using Fitness.Web.Data;
using Fitness.Web.Data.Models;
using Fitness.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fitness.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public HomeController(ApplicationDbContext context)
        {
            _ctx = context;
        }

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

        [Authorize]
        [HttpPost]
        public IActionResult Workout(WorkoutModel workoutModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid data. Try again.";
                return View(new WorkoutModel());
            }

            var user = _ctx.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            var workout = new Workout()
            {
                CaloriesBurned = workoutModel.CaloriesBurned,
                Date = workoutModel.Date,
                DurationMinutes = workoutModel.DurationMinutes,
                Type = workoutModel.Type
            };

            user.Workouts.Add(workout);
            _ctx.SaveChanges();

            TempData["SuccessMessage"] = "Workout successfully registered.";

            return View(new WorkoutModel());
        }

        [Authorize]
        public IActionResult WorkoutSummary()
        {
            var minDate = DateTime.Now.AddDays(-30);
            var user = _ctx.Users.Include(x => x.Workouts)
                .FirstOrDefault(u => u.Email == User.Identity.Name);

            var userWorkoutsForLastMonth = user.Workouts
                .Where(w => w.Date > minDate)
                .OrderByDescending(d => d.Date);

            var model = userWorkoutsForLastMonth.Select(x => new WorkoutModel
            {
                CaloriesBurned = x.CaloriesBurned,
                Date = x.Date,
                DurationMinutes = x.DurationMinutes,
                Type = x.Type
            })
            .ToList();

            return View(model);
        }
    }
}
