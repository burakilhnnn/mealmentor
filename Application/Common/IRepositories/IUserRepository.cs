using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Common.IRepositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken cancellationToken);

    }
}