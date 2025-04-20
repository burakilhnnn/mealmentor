using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MealPlan
    {
        public string Id { get; set; }
        public List<MealPlans> Plans { get; set; }
    }

    public class MealPlans
    {
        public string Id { get; set; }
        public List<MealRow> BreakfastRows { get; set; }
        public List<MealRow> LunchRows { get; set; }
        public List<MealRow> DinnerRows { get; set; }
        public List<MealRow> SnacksRows { get; set; }
        public string TabName { get; set; }
    }

    public class MealRow
    {
        public string Id { get; set; }
        public string MealPlansId { get; set; }
        public MealPlans MealPlans { get; set; }
        public string MealName { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
    }
}