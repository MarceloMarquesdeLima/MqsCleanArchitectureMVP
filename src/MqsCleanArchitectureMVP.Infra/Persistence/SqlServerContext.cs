using Microsoft.EntityFrameworkCore;
using MqsCleanArchitectureMVP.Domain.Entities;
using Nest;

namespace MqsCleanArchitectureMVP.Infra.Persistence
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; } 
    }
}
