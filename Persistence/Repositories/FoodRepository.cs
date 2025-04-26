using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Application.Common.IRepositories;
using Persistence.Context;
namespace Persistence.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Food food, CancellationToken cancellationToken)
        {
            await _context.Foods.AddAsync(food, cancellationToken);
        }
    }
}