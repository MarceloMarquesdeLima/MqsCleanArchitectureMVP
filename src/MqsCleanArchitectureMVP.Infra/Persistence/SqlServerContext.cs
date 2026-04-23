using Microsoft.EntityFrameworkCore;
using MqsCleanArchitectureMVP.Domain.Entities;
using Nest;

namespace MqsCleanArchitectureMVP.Infra.Persistence
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
        }
    }
}
