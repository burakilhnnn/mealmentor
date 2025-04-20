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
        public DateTime Date { get; set; }
        public string MealType { get; set; }
        public string MealName { get; set; }
        public string calories { get; set; }
        public string protein { get; set; }
        public string carbs { get; set; }
        public string fats { get; set; }
    }
}