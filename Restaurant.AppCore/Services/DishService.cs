namespace Restaurant.AppCore.Services
{
    using Restaurant.AppCore.Interfaces;
    using Restaurant.AppCore.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DishService" />.
    /// </summary>
    public class DishService
    {
        /// <summary>
        /// Defines the Repository.
        /// </summary>
        private readonly IRepository Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishService"/> class.
        /// </summary>
        /// <param name="repository">The repository<see cref="IRepository"/>.</param>
        public DishService(IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Gets all the dishes.
        /// </summary>
        /// <returns>The <see cref="List{Dish}"/>.</returns>
        public List<Dish> GetDishes()
        {
            List<Dish> dishes = Repository.GetDishes();

            return dishes;
        }
    }
}
