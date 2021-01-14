using HMS.Entities;
using System;
using System.Linq;

namespace HMS.BLL.Intefaces
{
    public interface IRoomBL
    {
        RoomEntity GetRoom(int id);
        IQueryable<RoomEntity> GetRooms();
        IQueryable<RoomEntity> GetRoomsByCity(string hotelCity);
        IQueryable<RoomEntity> GetRoomsByPinCode(string pinCode);
        IQueryable<RoomEntity> GetRoomsByPrice(decimal price);
        IQueryable<RoomEntity> GetRoomsByCategory(Category category);
        bool CheckAvailability(int roomId, DateTime checkDate);
        string CreateRoom(RoomEntity room);
    }
}
