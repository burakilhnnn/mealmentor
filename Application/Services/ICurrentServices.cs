using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Domain.Models;


namespace Application.Services
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }

    
}