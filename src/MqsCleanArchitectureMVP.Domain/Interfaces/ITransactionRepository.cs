using MqsCleanArchitectureMVP.Domain.Entities;

namespace MqsCleanArchitectureMVP.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);
        Task AddAsync(Transaction transaction);
    }
}
