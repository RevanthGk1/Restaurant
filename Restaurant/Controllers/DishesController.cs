namespace Restaurant.Controllers
{
    using Restaurant.AppCore.Interfaces;
    using Restaurant.AppCore.Models;
    using Restaurant.AppCore.Services;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="DishesController" />.
    /// </summary>
    public class DishesController : ApiController
    {
        /// <summary>
        /// Defines the Repository.
        /// </summary>
        internal IRepository Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishesController"/> class.
        /// </summary>
        /// <param name="repository">The repository<see cref="IRepository"/>.</param>
        public DishesController(IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Gets all dishes
        /// </summary>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            DishService dishService = new DishService(Repository);
            List<Dish> dishes = dishService.GetDishes();
            if (dishes == null || dishes.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dishes);
        }
    }
}
