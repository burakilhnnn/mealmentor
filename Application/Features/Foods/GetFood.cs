using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
namespace Application.Features.Foods
{
    public record GetFoodHandler(GetFoodRequest Request) : IRequest<GetFoodResponse>
    {
        public class Handler : IRequestHandler<GetFoodRequest, GetFoodResponse>
        {
            private readonly IUnitOfWorks _unitOfWorks;

            public Handler(IUnitOfWorks unitOfWorks)
            {
                _unitOfWorks = unitOfWorks;
            }

            public async Task<GetFoodResponse> Handle(GetFoodRequest request, CancellationToken cancellationToken)
            {
                var food = await _unitOfWorks.Foods.GetByNameAsync(request.MealName, cancellationToken);
                return new GetFoodResponse
                {
                    NutritionId = food.NutritionId,
                    MealName = food.MealName,
                    Calories = food.Calories,
                    Protein = food.Protein,
                    Carbs = food.Carbs,
                    Fats = food.Fats
                };
            }
        }
    }

    public class GetFoodRequest : IRequest<GetFoodResponse>
    {
        public string MealName { get; set; }
    }

    public class GetFoodResponse
    {
        public int NutritionId { get; set; }
        public string MealName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}