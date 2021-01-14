using HMS.BLL.Intefaces;
using HMS.DAL.Interface;
using HMS.Entities;
using System.Linq;

namespace HMS.BLL
{
    public class HotelBL : IHotelBL
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IRoomRepository _roomRepo;

        public HotelBL(IHotelRepository hotel, IRoomRepository room)
        {
            _hotelRepo = hotel;
            _roomRepo = room;
              
        }

        public string CreateHotel(HotelEntity hotel)
        {
            var res = _hotelRepo.CreateHotel(hotel);

            if (res)
                return "Success!!";

            return "Failure";

        }

        public HotelEntity GetHotel(int id)
        {
            var res = _hotelRepo.GetHotelById(id);

            return res;
        }

        public IQueryable<HotelEntity> GetHotels()
        {
            var res = _hotelRepo.GetHotels();

            return res;
        }
    }
}
