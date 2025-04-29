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
    public record GetHistoryHandler(GetHistoryRequest Request) : IRequest<GetHistoryResponse>
    {
        public class Handler : IRequestHandler<GetHistoryRequest, GetHistoryResponse>
        {
            private readonly IUnitOfWorks _unitOfWorks;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IUnitOfWorks unitOfWorks, ICurrentUserService currentUserService)
            {
                _unitOfWorks = unitOfWorks;
                _currentUserService = currentUserService;
            }

            public async Task<GetHistoryResponse> Handle(GetHistoryRequest request, CancellationToken cancellationToken)
            {
                var userId = _currentUserService.UserId;
                var histories = await _unitOfWorks.Histories.GetByUserIdAsync(userId, cancellationToken);

                return new GetHistoryResponse
                {
                    Histories = histories.Select(h => new HistoryDto
                    {
                        Id = h.Id,
                        UserId = h.UserId,
                        Date = h.Date,
                        MealType = h.MealType,
                        NutritionId = h.NutritionId,
                        Meal = h.Meal
                    }).ToList()
                };
            }
        }
    }

    public class GetHistoryResponse
    {
        public List<HistoryDto> Histories { get; set; }
    }

    public class HistoryDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string MealType { get; set; }
        public string NutritionId { get; set; }
        public Meal Meal { get; set; }
    }

    public class GetHistoryRequest : IRequest<GetHistoryResponse>
    {
    }
}