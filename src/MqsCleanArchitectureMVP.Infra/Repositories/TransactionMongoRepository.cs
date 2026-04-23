using MongoDB.Driver;
using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Persistence;

namespace MqsCleanArchitectureMVP.Infra.Repositories
{
    public class TransactionMongoRepository : ITransactionRepository
    {
        private readonly MongoContext _context;

        public TransactionMongoRepository(MongoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
        {
            var filter = Builders<Transaction>.Filter.Eq(t => t.AccountId, accountId);
            return await _context.Transactions.Find(filter).ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.InsertOneAsync(transaction);
        }
    }
}
