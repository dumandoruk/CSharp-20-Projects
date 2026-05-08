using MongoDB.Bson;
using MongoDB.Driver;
using Project9_MongoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project9_MongoDb.Services
{
    public class OrderOperation
    {
        public void AddOrder(Order order)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollection();

            var document = new BsonDocument
            {
                {"OrderID", order.OrderID },
                {"CustomerName", order.CustomerName},
                {"City", order.City},
                {"District", order.District},
                {"TotalPrice", order.TotalPrice}
            };

            orderCollection.InsertOne(document);
        }   

        public void DeleteOrder(string id)
        {
            var connection = new MongoDbConnection();

            var orderCollection = connection.GetOrdersCollection().Database.GetCollection<Order>("Orders");

            var filter = Builders<Order>.Filter.Eq("_id", new ObjectId(id));
            orderCollection.DeleteOne(filter);
        }

        public List<Order> GetAllOrders()
        {
            var connection = new MongoDbConnection();

            var orderCollection = connection.GetOrdersCollection().Database.GetCollection<Order>("Orders");

            return orderCollection.Find(new BsonDocument()).ToList();
        }
    }
}
