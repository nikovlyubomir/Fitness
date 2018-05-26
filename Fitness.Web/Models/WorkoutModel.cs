using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Web.Models
{
    public class WorkoutModel
    {
        public string Type { get; set; }
        public double CaloriesBurned { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime Date { get; set; }
    }
}
