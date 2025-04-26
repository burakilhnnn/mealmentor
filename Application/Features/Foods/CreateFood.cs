using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using Application.Common.IRepositories;


namespace Application.Features.Foods
{
    public class CreateFoodHandler : IRequestHandler<CreateFoodRequest, List<Food>>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CreateFoodHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<List<Food>> Handle(CreateFoodRequest request, CancellationToken cancellationToken)
        {
            var foods = new List<Food>();

            foreach (var foodDto in request.Foods)
            {
                var food = new Food
                {
                    NutritionId = foodDto.NutritionId,
                    MealName = foodDto.MealName,
                    Calories = foodDto.Calories,
                    Protein = foodDto.Protein,
                    Carbs = foodDto.Carbs,
                    Fats = foodDto.Fats
                };

                await _unitOfWorks.Foods.AddAsync(food, cancellationToken);
                foods.Add(food);
            }

            await _unitOfWorks.SaveAsync();
            return foods;
        }
    }

    public class CreateFoodRequest : IRequest<List<Food>>
    {
        public List<FoodDto> Foods { get; set; }
    }

    public class FoodDto
    {
        public int NutritionId { get; set; }
        public string MealName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}