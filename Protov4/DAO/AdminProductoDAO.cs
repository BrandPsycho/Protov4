using MongoDB.Driver;
using Protov4.DTO;

namespace Protov4.DAO
{
    public class AdminProductoDAO
    {
        private readonly IMongoCollection<ProductoDTO> prod;
        public AdminProductoDAO(IConfiguration configuration)
        {
            var mongo = new DBMongo(configuration);
            prod = mongo.GetDatabase().GetCollection<ProductoDTO>("Productos");
        }

    }
}
