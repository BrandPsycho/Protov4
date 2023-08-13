using MongoDB.Driver;
namespace Protov4.DAO
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<ProductoDAO> YourEntities => _database.GetCollection<ProductoDAO>("Productos");
    }
}
