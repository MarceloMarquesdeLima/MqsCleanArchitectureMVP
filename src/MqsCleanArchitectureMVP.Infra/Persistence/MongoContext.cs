using MongoDB.Driver;
using MqsCleanArchitectureMVP.Domain.Entities;

namespace MqsCleanArchitectureMVP.Infra.Persistence
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(dbName);
        }

        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Accounts");
    }
}
