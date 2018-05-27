using Fitness.Web.Data;
using Fitness.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fitness.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public AdministratorController(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IActionResult Users()
        {
            var currentUserEmail = User.Identity.Name;
            var users = _ctx.Users
                .Where(u => u.Email != currentUserEmail)
                .Select(u => u.Email)
                .ToList();

            return View(users);
        }

        public IActionResult DeleteUser(string userEmail)
        {
            ViewData["userEmail"] = userEmail;
            return View();
        }

        public IActionResult DeleteByEmail(string userEmail)
        {
            var userToDelete = _ctx.Users.FirstOrDefault(u => u.Email == userEmail);
            _ctx.Users.Remove(userToDelete);
            _ctx.SaveChanges();

            TempData["SuccessMessage"] = "User successfuly deleted.";

            return RedirectToAction(nameof(AdministratorController.Users));
        }
    }
}