using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using Application.Services;

namespace Application.Features.Histories
{
    public class CreateHistoryHandler : IRequestHandler<CreateHistoryRequest, History>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ICurrentUserService _currentUserService;

        public CreateHistoryHandler(IUnitOfWorks unitOfWorks, ICurrentUserService currentUserService)
        {
            _unitOfWorks = unitOfWorks;
            _currentUserService = currentUserService;
        }

        public async Task<History> Handle(CreateHistoryRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var history = new History
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                MealType = request.MealType,
                NutritionId = Guid.NewGuid().ToString(),
        
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