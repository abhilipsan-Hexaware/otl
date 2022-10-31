using logging.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace logging.Data.Repositories
{
    public class MongoDBGateway : IGateway
    {
        private IConfiguration _configuration;
        public MongoDBGateway(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IMongoDatabase GetMongoDB()
        {
            string connectionString = _configuration.GetSection("MongoDb")["connectionString"];
            string database = _configuration.GetSection("MongoDb")["Database"];
            MongoClient client = new MongoClient(connectionString);
            return client.GetDatabase(database);

        }
    }
}
