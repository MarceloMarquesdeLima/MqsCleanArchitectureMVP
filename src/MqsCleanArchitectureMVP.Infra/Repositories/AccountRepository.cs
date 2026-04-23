using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Persistence;

namespace MqsCleanArchitectureMVP.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlServerContext _context;

        public AccountRepository(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
