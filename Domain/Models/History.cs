using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string MealType { get; set; }
        public string NutritionId { get; set; }
        public Meal Meal { get; set; }
    }
}