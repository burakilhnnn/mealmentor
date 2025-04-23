using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using BCrypt.Net;

namespace Application.Features.Auth
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public RegisterHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _unitOfWorks.Users.GetByEmailAsync(request.Email, cancellationToken);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User(Guid.NewGuid(), request.Email, hashedPassword);

            await _unitOfWorks.Users.AddAsync(user, cancellationToken);

            return new RegisterResponse
            {
                Id = user.Id,
                Email = user.Email
            };
        }
    }
} 