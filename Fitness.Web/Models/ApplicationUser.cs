using Fitness.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Fitness.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Workouts = new HashSet<Workout>();
        }
        public ICollection<Workout> Workouts { get; set; }
    }
}
