namespace Restaurant.Infrastructure
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Restaurant.AppCore.Interfaces;
    using Restaurant.AppCore.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// Defines the <see cref="Repository" />.
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Defines the ConnectionStr.
        /// </summary>
        private readonly string ConnectionStr;

        /// <summary>
        /// Defines the DbClient.
        /// </summary>
        private readonly MongoClient DbClient;

        //public Repository(string connStr)
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository(string connStr)
        {
            ConnectionStr = ConfigurationManager.ConnectionStrings["mongodbconnection"].ConnectionString;
            if (!string.IsNullOrEmpty(connStr))
                this.ConnectionStr = connStr;
            DbClient = new MongoClient(ConnectionStr);
        }

        /// <summary>
        /// The GetDishes.
        /// </summary>
        /// <returns>The <see cref="List{Dish}"/>.</returns>
        public List<Dish> GetDishes()
        {
            IMongoDatabase restaurantDb = DbClient.GetDatabase("Restaurant");
            IMongoCollection<Dish> dishesCollection = restaurantDb.GetCollection<Dish>("Dishes");
            List<Dish> lstDish = dishesCollection.Find(new BsonDocument()).ToList();
            foreach (Dish dish in lstDish)
            {
                Console.WriteLine(dish.AvailableFor[0].ToString());
            }

            // Another method to get Bson collection and then map it to individual entities as needed.
            //var dishesBsonCollection = restaurantDb.GetCollection<BsonDocument>("Dishes");
            //var lstBsonDocs = dishesBsonCollection.Find(new BsonDocument()).ToList();
            //BsonValue val;
            //foreach (BsonDocument doc in lstBsonDocs)
            //{
            //    doc.TryGetValue("Name", out val);
            //    Console.WriteLine(val.ToString());
            //}

            return lstDish;
        }
    }
}
