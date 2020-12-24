namespace Restaurant.AppCore.Interfaces
{
    using Restaurant.AppCore.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IRepository" />.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets all dishes.
        /// </summary>
        /// <returns>The <see cref="List{Dish}"/>.</returns>
        List<Dish> GetDishes();
    }
}
