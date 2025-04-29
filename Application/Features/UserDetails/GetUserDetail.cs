using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using Application.Services;

namespace Application.Features.UserDetails
{
    public record GetUserDetailsHandler(GetUserDetailsRequest Request) : IRequest<GetUserDetailsResponse>
    {
        public class Handler : IRequestHandler<GetUserDetailsRequest, GetUserDetailsResponse>
        {
            private readonly IUnitOfWorks _unitOfWorks;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IUnitOfWorks unitOfWorks, ICurrentUserService currentUserService)
            {
                _unitOfWorks = unitOfWorks;
                _currentUserService = currentUserService;
            }

            public async Task<GetUserDetailsResponse> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
            {
                var userId = _currentUserService.UserId;
                var userDetail = await _unitOfWorks.UserDetails.GetByIdAsync(userId, cancellationToken);

                return new GetUserDetailsResponse
                {
                    UserId = userDetail.UserId,
                    Sex = userDetail.Sex,
                    Age = userDetail.Age,
                    Height = userDetail.Height,
                    Weight = userDetail.Weight,
                    ActivityLevel = userDetail.ActivityLevel,
                    Goal = userDetail.Goal,
                    RateOfFatLossMuscleGain = userDetail.RateOfFatLossMuscleGain,
                    KgToLoseGainPerWeek = userDetail.KgToLoseGainPerWeek,
                    Bmr = userDetail.Bmr,
                    Tdee = userDetail.Tdee,
                    DailyCalories = userDetail.DailyCalories,
                    ProteinGrams = userDetail.ProteinGrams,
                    CarbsGrams = userDetail.CarbsGrams,
                    FatGrams = userDetail.FatGrams,
                    PercentProtein = userDetail.PercentProtein,
                    PercentCarbs = userDetail.PercentCarbs,
                    PercentFat = userDetail.PercentFat,
                    DieseaseType = userDetail.DieseaseType,
                    Severity = userDetail.Severity,
                    Bmi = userDetail.Bmi,
                    DietaryRestrictions = userDetail.DietaryRestrictions,
                    Allergies = userDetail.Allergies,
                    DietaryRecommendation = userDetail.DietaryRecommendation
                };
            }
        }
    }

    public class GetUserDetailsResponse
    {
        public Guid UserId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string ActivityLevel { get; set; }
        public string Goal { get; set; }
        public string RateOfFatLossMuscleGain { get; set; }
        public double KgToLoseGainPerWeek { get; set; }
        public int Bmr { get; set; }
        public int Tdee { get; set; }
        public int DailyCalories { get; set; }
        public int ProteinGrams { get; set; }
        public int CarbsGrams { get; set; }
        public int FatGrams { get; set; }
        public int PercentProtein { get; set; }
        public int PercentCarbs { get; set; }
        public int PercentFat { get; set; }
        public string DieseaseType { get; set; }
        public string Severity { get; set; }
        public string Bmi { get; set; }
        public string DietaryRestrictions { get; set; }
        public string Allergies { get; set; }
        public string DietaryRecommendation { get; set; }
    }

    public class GetUserDetailsRequest : IRequest<GetUserDetailsResponse>
    {
    }
}