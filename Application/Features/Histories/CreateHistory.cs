using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;

namespace Application.Features.Histories
{
    public class CreateHistoryHandler : IRequestHandler<CreateHistoryRequest, History>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CreateHistoryHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<History> Handle(CreateHistoryRequest request, CancellationToken cancellationToken)
        {
            var history = new History
            {
                Id = Guid.NewGuid(),
                MealType = request.MealType,
                NutritionId = Guid.NewGuid().ToString(),
                Meal = new Meal
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName = request.MealName,
                    Calories = request.Calories,
                    Protein = request.Protein,
                    Carbs = request.Carbs,
                    Fats = request.Fats
                }
            };

            await _unitOfWorks.Histories.AddAsync(history, cancellationToken);
            await _unitOfWorks.SaveAsync();
            return history;
        }
    }

    public class CreateHistoryRequest : IRequest<History>
    {
        public string MealName { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public string MealType { get; set; }
        public string NutritionId { get; set; }
    }
}