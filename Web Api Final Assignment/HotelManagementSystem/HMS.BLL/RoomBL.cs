using HMS.BLL.Intefaces;
using HMS.DAL.Interface;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL
{
    public class RoomBL : IRoomBL
    {
        private readonly IRoomRepository _roomRepo;
        
        public RoomBL(IRoomRepository room)
        {
            _roomRepo = room;
        }

        public bool CheckAvailability(int roomId, DateTime checkDate)
        {
            var res = _roomRepo.CheckAvailability(roomId, checkDate);

            return res;
        }

        public string CreateRoom(RoomEntity room)
        {
            var res = _roomRepo.CreateRoom(room);

            if (res)
                return "Success";

            return "Failure";
        }

        public RoomEntity GetRoom(int id)
        {
            return _roomRepo.GetRoom(id);
        }

        public IQueryable<RoomEntity> GetRooms()
        {
            return _roomRepo.GetRooms();
        }

        public IQueryable<RoomEntity> GetRoomsByCategory(Category category)
        {
            return _roomRepo.GetRoomsByCategory(category); 
        }

        public IQueryable<RoomEntity> GetRoomsByCity(string hotelCity)
        {
            return _roomRepo.GetRoomsByCity(hotelCity);
        }

        public IQueryable<RoomEntity> GetRoomsByPinCode(string pinCode)
        {
            return _roomRepo.GetRoomsByPinCode(pinCode);
        }

        public IQueryable<RoomEntity> GetRoomsByPrice(decimal price)
        {
            return _roomRepo.GetRoomsByPrice(price);
        }
    }
}
