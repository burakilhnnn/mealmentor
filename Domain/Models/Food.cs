using System;

namespace Domain.Models
{
    public class Food
    {
        public int NutritionId { get; set; }
        public string MealName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
} 