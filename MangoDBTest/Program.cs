using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;

namespace MangoDBTest
{
    static class Program
    {
        static void Main()
        {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");

            IMongoCollection<ColEntity> collection = database.GetCollection<ColEntity>("col");
            var colOne = collection.Find(f=>f.title == "MongoDB").FirstOrDefault();


        }
    }
}
