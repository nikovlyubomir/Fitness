using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Web.API
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public UsersController(ApplicationDbContext context)
        {
            _ctx = context;
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            return _ctx.Users
                .Select(u => u.Email)
                .ToList();
        }
    }
}