using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.IUnitOfWorks;
using Application.Common.IRepositories;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly AppDbContext _context;
        private IUserRepository _users;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public int Save() => _context.SaveChanges();

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }
      
    }
}