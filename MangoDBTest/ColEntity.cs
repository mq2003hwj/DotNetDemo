using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoDBTest
{
    public class ColEntity
    {
        public ObjectId id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int likes { get; set; }
    }
}
