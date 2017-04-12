using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest
{
    public class TestPo
    {
        public ObjectId id { get; set; }

        public int size { get; set; }

        public string reason { get; set; }

        public string title { get; set; }
    }
}
