using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliPC
{
    class UsersModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public bool isAdmin { get; set; }
        [BsonElement]
        public string Username { get; set; }
        [BsonElement]
        public string Password { get; set; }
        [BsonElement]
        public double Salary { get; set; }
        [BsonElement]
        public double Workhours { get; set; }


    }
}
