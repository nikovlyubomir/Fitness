using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Web.Models
{
    public class WorkoutModel
    {
        public string Type { get; set; }
        [Range(1,1000)]
        public double CaloriesBurned { get; set; }
        [Range(1,200)]
        public int DurationMinutes { get; set; }
        public DateTime Date { get; set; }
    }
}
