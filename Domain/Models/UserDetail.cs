using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserDetail
    {

        public UserDetail(string sex, int age, int height, int weight, string activityLevel, string goal, string rateOfFatLossMuscleGain, double kgToLoseGainPerWeek, int bmr, int tdee, int dailyCalories, int proteinGrams, int carbsGrams, int fatGrams, int percentProtein, int percentCarbs, int percentFat, string dieseaseType, string severity, string bmi, string dietaryRestrictions, string dietaryRecommendation, string allergies)
        {
            Sex = sex;
            Age = age;
            Height = height;
            Weight = weight;
            ActivityLevel = activityLevel;
            Goal = goal;
            RateOfFatLossMuscleGain = rateOfFatLossMuscleGain;
            KgToLoseGainPerWeek = kgToLoseGainPerWeek;
            Bmr = bmr;
            Tdee = tdee;
            DailyCalories = dailyCalories;
            ProteinGrams = proteinGrams;
            CarbsGrams = carbsGrams;
            FatGrams = fatGrams;
            PercentProtein = percentProtein;
            PercentCarbs = percentCarbs;
            PercentFat = percentFat;
            DieseaseType = dieseaseType;
            Severity = severity;
            Bmi = bmi;
            DietaryRestrictions = dietaryRestrictions;
            DietaryRecommendation = dietaryRecommendation;
            Allergies = allergies;
        }

        public Guid UserId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string ActivityLevel { get; set; }
        public string Goal { get; set; }
        public string RateOfFatLossMuscleGain { get; set; }
        public double KgToLoseGainPerWeek { get; set; }
        public int Bmr { get; set; }
        public int Tdee { get; set; }
        public int DailyCalories { get; set; }
        public int ProteinGrams { get; set; }
        public int CarbsGrams { get; set; }
        public int FatGrams { get; set; }
        public int PercentProtein { get; set; }
        public int PercentCarbs { get; set; }
        public int PercentFat { get; set; }
        public string DieseaseType { get; set; }
        public string Severity { get; set; }
        public string Bmi { get; set; }
        public string DietaryRestrictions { get; set; }
        public string DietaryRecommendation { get; set; }
        public string Allergies { get; set; }

    }
}