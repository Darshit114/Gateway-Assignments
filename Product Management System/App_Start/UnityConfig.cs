using PMS.BLL;
using PMS.BLL.Helper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Product_Management_System.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductBLL, ProductBLL>();
            container.RegisterType<IUserBLL, UserBLL>();

            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}