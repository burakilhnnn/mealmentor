using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Auth
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
} 