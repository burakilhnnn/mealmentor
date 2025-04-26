using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Common.IRepositories
{
    public interface IFoodRepository
    {
        Task AddAsync(Food food, CancellationToken cancellationToken);
        Task<Food> GetByNameAsync(string mealName, CancellationToken cancellationToken);
    }
}