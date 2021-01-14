using HMS.Entities;
using System.Linq;

namespace HMS.BLL.Intefaces
{
    public interface IHotelBL
    {
        HotelEntity GetHotel(int id);
        IQueryable<HotelEntity> GetHotels();
        string CreateHotel(HotelEntity hotel);
    }
}
