using HMS.Entities;
using System.Linq;

namespace HMS.DAL.Interface
{
    public interface IHotelRepository
    {
        HotelEntity GetHotelById(int id);
        IQueryable<HotelEntity> GetHotels();
        bool CreateHotel(HotelEntity hotel);
    }
}
