using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliPC
{
    class Login
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
       [BsonElement("password")]
       public string Password { get; set; }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
