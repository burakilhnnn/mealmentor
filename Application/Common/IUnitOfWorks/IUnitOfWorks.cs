using System.Threading.Tasks;
using Domain.Models;
using Application.Common.IRepositories;
namespace Application.Common.IUnitOfWorks
{
    public interface IUnitOfWorks
    {
        IUserRepository Users { get; }
        IUserDetailRepository UserDetails { get; }
        IHistoryRepository Histories { get; }
        Task<int> SaveAsync();
        
        ValueTask DisposeAsync();


         int Save();


    }
} 