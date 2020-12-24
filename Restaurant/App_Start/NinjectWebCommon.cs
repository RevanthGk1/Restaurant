[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Restaurant.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Restaurant.App_Start.NinjectWebCommon), "Stop")]
namespace Restaurant.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Restaurant.AppCore.Interfaces;
    using Restaurant.Infrastructure;
    using System;
    using System.Configuration;
    using System.Web;

    /// <summary>
    /// Defines the <see cref="NinjectWebCommon" />.
    /// </summary>
    public static class NinjectWebCommon
    {
        /// <summary>
        /// Defines the bootstrapper.
        /// </summary>
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            StandardKernel kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            string connStr = ConfigurationManager.ConnectionStrings["mongodbconnection"].ConnectionString;
            kernel.Bind<IRepository>().To<Repository>()
                .WithConstructorArgument("connStr", connStr);
        }
    }
}
