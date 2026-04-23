using MqsCleanArchitectureMVP.Domain.Entities;

namespace MqsCleanArchitectureMVP.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
    }
}
