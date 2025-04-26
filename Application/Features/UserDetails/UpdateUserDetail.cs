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
    public class UpdateUserDetailHandler : IRequestHandler<UpdateUserDetailRequest, UserDetail>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserDetailHandler(
            IUnitOfWorks unitOfWorks,
            ICurrentUserService currentUserService)
        {
            _unitOfWorks = unitOfWorks;
            _currentUserService = currentUserService;
        }

        public async Task<UserDetail> Handle(UpdateUserDetailRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            var userDetail = await _unitOfWorks.UserDetails.GetByIdAsync(userId, cancellationToken);

            userDetail.Sex = request.Sex;
            userDetail.Age = request.Age;
            userDetail.Height = request.Height;
            userDetail.Weight = request.Weight;
            userDetail.ActivityLevel = request.ActivityLevel;
            userDetail.Goal = request.Goal;
            userDetail.RateOfFatLossMuscleGain = request.RateOfFatLossMuscleGain;
            userDetail.KgToLoseGainPerWeek = request.KgToLoseGainPerWeek;
            userDetail.Bmr = request.Bmr;
            userDetail.Tdee = request.Tdee;
            userDetail.DailyCalories = request.DailyCalories;
            userDetail.ProteinGrams = request.ProteinGrams;
            userDetail.CarbsGrams = request.CarbsGrams;
            userDetail.FatGrams = request.FatGrams;
            userDetail.PercentProtein = request.PercentProtein;
            userDetail.PercentCarbs = request.PercentCarbs;
            userDetail.PercentFat = request.PercentFat;

            await _unitOfWorks.SaveAsync();

            return userDetail;
        }
    }

    public class UpdateUserDetailRequest : IRequest<UserDetail>
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

    }
}