using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.IUnitOfWorks;
using Domain.Models;
using MediatR;
using Application.Services;

namespace Application.Features.UserDetails
{
    public class CreateUserDetailHandler : IRequestHandler<CreateUserDetailRequest, UserDetail>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ICurrentUserService _currentUserService;

        public CreateUserDetailHandler(IUnitOfWorks unitOfWorks, ICurrentUserService currentUserService)
        {
            _unitOfWorks = unitOfWorks;
            _currentUserService = currentUserService;
        }

        public async Task<UserDetail> Handle(CreateUserDetailRequest request, CancellationToken cancellationToken)
        {
            var userDetail = new UserDetail(request.Sex, request.Age, request.Height, request.Weight, request.ActivityLevel, request.Goal, request.RateOfFatLossMuscleGain, request.KgToLoseGainPerWeek, request.Bmr, request.Tdee, request.DailyCalories, request.ProteinGrams, request.CarbsGrams, request.FatGrams, request.PercentProtein, request.PercentCarbs, request.PercentFat, request.DieseaseType, request.Severity, request.Bmi, request.DietaryRestrictions, request.Allergies);
            userDetail.UserId = _currentUserService.UserId;
            await _unitOfWorks.UserDetails.AddAsync(userDetail, cancellationToken);
            await _unitOfWorks.SaveAsync();
            return userDetail;
        }

    }

    public class CreateUserDetailRequest : IRequest<UserDetail>
    {
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


    }
}