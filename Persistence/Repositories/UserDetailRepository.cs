using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Application.Common.IRepositories;
using Persistence.Context;
using System.Threading;

namespace Persistence.Repositories
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly AppDbContext _dbContext;

        public UserDetailRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserDetail userDetail, CancellationToken cancellationToken)
        {
            await _dbContext.UserDetails.AddAsync(userDetail, cancellationToken);
        }
        
    }
}