using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularNet.Models;
using MongoDB.Driver;

namespace AngularNet.Services
{
    public class BusinessService
    {
        private readonly IMongoCollection<Business> _business;
        public BusinessService(IBusinessDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _business = database.GetCollection<Business>(settings.BusinessCollectionName);
        }

        public List<Business> Get() =>
            _business.Find(book => true).ToList();

        public Business Get(string id) =>
            _business.Find<Business>(item => item.Id == id).FirstOrDefault();

        public Business Create(Business business)
        {
            _business.InsertOne(business);
            return business;
        }

        public void Update(string id, Business businessIn) =>
            _business.ReplaceOne(item => item.Id == id, businessIn);

        public void Remove(Business businessIn) =>
            _business.DeleteOne(item => item.Id == businessIn.Id);

        public void Remove(string id) =>
            _business.DeleteOne(item => item.Id == id);
    }
}
