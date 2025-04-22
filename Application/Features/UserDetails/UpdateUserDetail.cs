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
            userDetail.RateOfFatLossMuscleGain = request.rateOfFatLossMuscleGain;

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
        public string rateOfFatLossMuscleGain { get; set; }
    }
}