using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MVVMLesson.Model.Tools
{
    class DBContext
    {
        private static DBContext _instance;

        public CollectionPhones CollectionPhones { get; private set; }

        private DBContext() 
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("shop");
            CollectionPhones = new CollectionPhones(db.GetCollection<Phone>("phones"));
        }

        public static DBContext GetInstance()
        {
            if (_instance == null)
                _instance = new DBContext();

            return _instance;
        }
    }
}
