//using MongoDB.Bson;

namespace Restaurant.AppCore.Models
{
    /// <summary>
    /// Defines the <see cref="Dish" />.
    /// </summary>
    public class Dish
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Gets or sets the Dish_id.
        /// </summary>
        public int Dish_id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Desc.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the WaitingTime.
        /// </summary>
        public int WaitingTime { get; set; }

        /// <summary>
        /// Gets or sets the AvailableFor.
        /// </summary>
        public string[] AvailableFor { get; set; }
    }
}
