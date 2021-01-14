using HMS.BLL;
using HMS.BLL.Helper;
using HMS.BLL.Intefaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HotelManagementSystem.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IHotelBL, HotelBL>();
            container.RegisterType<IRoomBL, RoomBL>();
            container.RegisterType<IBookingBL, BookingBL>();

            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}