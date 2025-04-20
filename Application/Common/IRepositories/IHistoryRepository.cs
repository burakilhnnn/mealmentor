using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Common.IRepositories
{
    public interface IHistoryRepository
    {
        Task AddAsync(History history, CancellationToken cancellationToken);
    }
}