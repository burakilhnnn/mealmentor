using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common;
using Application.Common.IUnitOfWorks;

namespace Application.Features.Users
{

        public class CreateUserHandler : IRequestHandler<CreateUserRequest, User>
    {
        private readonly IUnitOfWorks _unitOfWork;

        public CreateUserHandler(IUnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User(Guid.NewGuid(), request.Email, request.Password);

            await _unitOfWork.Users.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveAsync();

            return user;
        }
    }
    public class CreateUserRequest : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


}