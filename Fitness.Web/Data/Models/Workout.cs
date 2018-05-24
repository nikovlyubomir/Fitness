using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Web.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double CaloriesBurned { get; set; }
        public int DurationMinutes { get; set; }
    }
}
