namespace Restaurant
{
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="WebApiApplication" />.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The Application_Start.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
