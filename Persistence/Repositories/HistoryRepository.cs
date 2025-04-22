using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Application.Common.IRepositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDbContext _context;

        public HistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(History history, CancellationToken cancellationToken)
        {
            await _context.Histories.AddAsync(history, cancellationToken);
        }

        public async Task Delete(History history)
        {
            _context.Histories.Remove(history);
        }

        public async Task<History> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Histories.FindAsync(id, cancellationToken);
        }
    }
}