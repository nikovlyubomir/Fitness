using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Web.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Fitness.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Workouts = new HashSet<Workout>();
        }
        public ICollection<Workout> Workouts { get; set; }
    }
}
