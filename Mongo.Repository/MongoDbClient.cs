using Mongo.Repository.Extensions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Repository
{
    public interface IMongoDbClient
    {
        IMongoDatabase MongoDatabase { get; }
    }
    public class MongoDbClient: IMongoDbClient
    {
        public IMongoDatabase MongoDatabase { get; }
        public MongoDbClient(IMongoDbSettings settings) {

            MongoDatabase = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        }
    }
}
