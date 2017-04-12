using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;

namespace MongoDbTest
{
    public static class MongoRepository
    {
        public const string ConnectionString = "mongodb://localhost:27017";

        private static IMongoDatabase _instance;

        public static IMongoDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    var client = new MongoClient(ConnectionString);
                    _instance = client.GetDatabase("ymt");
                }

                return _instance;
            }
        }
    }
}
