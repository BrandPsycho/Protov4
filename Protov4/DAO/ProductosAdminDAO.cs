using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Protov4.DTO;
using Protov4.Models;

namespace Protov4.DAO
{
    public class ProductosAdminDAO
    {
        private readonly IMongoCollection<ProductoDAO> _productoCollection;

        public ProductoService(IOptions<ProductosDatabaseSettings> productotoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                productotoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productotoreDatabaseSettings.Value.DatabaseName);

            _productoCollection = (IMongoCollection<ProductoDAO>?)mongoDatabase.GetCollection<ProductoDTO>(
                productotoreDatabaseSettings.Value.MikuCollection);
        }

        public async Task<List<Book>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
}
