using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using System.Threading;


namespace Application.Common.IRepositories
{
    public interface IUserDetailRepository
    {
        Task AddAsync(UserDetail userDetail, CancellationToken cancellationToken);
        Task<UserDetail> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    }
}