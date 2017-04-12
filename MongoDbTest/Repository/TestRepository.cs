using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest.Repository
{
    public class TestRepository
    {
        public async Task<IAsyncCursor<TestPo>> GetCollectionAsync(BsonDocument document)
        {
            var database = MongoRepository.Instance;
            var col = database.GetCollection<TestPo>("test");

            BsonDocumentFilterDefinition<TestPo> filter = new BsonDocumentFilterDefinition<TestPo>(document);
            var list = await col.FindAsync<TestPo>(filter);

            return list;
        }

        public async Task<IAsyncCursor<TestPo>> GetOneAsync(BsonDocument document)
        {
            var database = MongoRepository.Instance;
            var col = database.GetCollection<TestPo>("test");

            FindOptions<TestPo, TestPo> fo = new FindOptions<TestPo, TestPo>
            {
                Limit = 1,
            };

            BsonDocumentFilterDefinition<TestPo> filter = new BsonDocumentFilterDefinition<TestPo>(document);
            var list = await col.FindAsync<TestPo>(filter, fo);

            return list;
        }


        public async Task<string> AddCollectionAsync(TestPo test)
        {
            var database = MongoRepository.Instance;
            var col = database.GetCollection<TestPo>("test");

            await col.InsertOneAsync(test);

            return "ok";
        }

        public async Task<string> UpdateCollectionAsync(BsonDocument filterDocument,BsonDocument updateDocument)
        {
            var database = MongoRepository.Instance;
            var col = database.GetCollection<TestPo>("test");


            var filterDef = new BsonDocumentFilterDefinition<TestPo>(filterDocument);
            var updateDef = new BsonDocumentUpdateDefinition<TestPo>(updateDocument);

            await col.UpdateOneAsync(filterDef, updateDef);

            return "ok";
        }


        public async Task<string> DeleteCollectionAsync(BsonDocument filterDocument)
        {
            var database = MongoRepository.Instance;
            var col = database.GetCollection<TestPo>("test");

            var filterDef = new BsonDocumentFilterDefinition<TestPo>(filterDocument);
            await col.DeleteOneAsync(filterDef);

            return "ok";
        }
    }
}
