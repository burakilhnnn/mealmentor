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
                if (string.IsNullOrWhiteSpace(request.MealName))
                {
                    return new GetFoodResponse { Foods = new List<FoodDto>() };
                }

                var foods = await _unitOfWorks.Foods.GetByNameAsync(request.MealName, cancellationToken);
                if (foods == null || !foods.Any())
                {
                    return new GetFoodResponse { Foods = new List<FoodDto>() };
                }

                return new GetFoodResponse
                {
                    Foods = foods.Select(f => new FoodDto
                    {
                        NutritionId = f.NutritionId,
                        MealName = f.MealName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fats = f.Fats
                    }).ToList()
                };
            }
        }
    }

    public class GetFoodRequest : IRequest<GetFoodResponse>
    {
        public string? MealName { get; set; }
    }

    public class GetFoodResponse
    {
        public List<FoodDto> Foods { get; set; }
    }
}