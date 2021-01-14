using HMS.DAL.Interface;
using HMS.DAL.Repository;
using Unity.Extension;
using Unity;

namespace HMS.BLL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBookingRepository, BookingRepository>();
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
        }
    }
}
