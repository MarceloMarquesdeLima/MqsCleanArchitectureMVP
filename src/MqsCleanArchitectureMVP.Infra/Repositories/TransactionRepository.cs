using MongoDB.Driver;
using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Persistence;

namespace MqsCleanArchitectureMVP.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SqlServerContext _context;

        public TransactionRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
        {
            return await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .ToListAsync(); // ✅ funciona com EF Core
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
