using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MVVMLesson.Model
{
    class CollectionPhones
    {
        private IMongoCollection<Phone> _phones;

        public CollectionPhones(IMongoCollection<Phone> phones)
        {
            _phones = phones;
        }

        public void AddPhone(Phone phone)
        {
            _phones.InsertOne(phone);
        }

        public void DeletePhone(Phone phone)
        {
            _phones.DeleteOne(x => x.Id == phone.Id);
        }

        public void UpdatePhone(Phone phone)
        {
            _phones.ReplaceOne(x => x.Id == phone.Id, phone);
        }

        public List<Phone> GetAllPhones()
        {
            return _phones.Find(new BsonDocument()).ToList();
        }
    }
}
