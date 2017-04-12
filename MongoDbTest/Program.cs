using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestRepository testRepository = new TestRepository();

            var filterDoc = new BsonDocument("title", new BsonString("昨天有的啊"));

            var one = testRepository.GetOneAsync(filterDoc).Result.FirstOrDefault();
            Console.WriteLine(one.ToJson());
            Console.ReadKey();

            var two = new TestPo
            {
                reason = "cao ni ma",
                size = 15,
                title = "屌炸JB天"
            };
            var ok = testRepository.AddCollectionAsync(two).Result;
            ViewCollection();
            Console.ReadKey();


            filterDoc = new BsonDocument("reason", new BsonString("cao ni ma"));

            ok = testRepository.DeleteCollectionAsync(filterDoc).Result;
            ViewCollection();
            Console.ReadKey();

            filterDoc = new BsonDocument("size",new BsonInt32(15));
            one = testRepository.GetOneAsync(filterDoc).Result.FirstOrDefault();
            var updateDoc = new BsonDocument("$set",new BsonDocument("size",2000));
            ok = testRepository.UpdateCollectionAsync(filterDoc,updateDoc).Result;

            ViewCollection();

            Console.WriteLine("Main is over!");

            Console.ReadKey();
        }

        private static void ViewCollection()
        {
            var list = new TestRepository().GetCollectionAsync(new BsonDocument());
            foreach (var l in list.Result.ToList())
            {
                Console.WriteLine(l.ToJson());
            }
        }


    }
}
