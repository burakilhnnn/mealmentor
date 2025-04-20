using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserDetail
    {
        public Guid UserId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string ActivityLevel { get; set; }
        public string Goal { get; set; }
        public string rateOfFatLossMuscleGain { get; set; }
        public double poundsToLoseGainPerWeek { get; set; }
        public int bmr { get; set; }
        public int tdee { get; set; }
        public int dailyCalories { get; set; }
        public int proteinGrams { get; set; }
        public int carbsGrams { get; set; }
        public int fatGrams { get; set; }
        public int percentProtein { get; set; }
        public int percentCarbs { get; set; }
        public int percentFat { get; set; }
        public bool userStatsExist { get; set; }
    }
}