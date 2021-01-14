using HMS.Entities;
using System;
using System.Linq;

namespace HMS.DAL.Interface
{
    public interface IRoomRepository
    {
        RoomEntity GetRoom(int id);
        IQueryable<RoomEntity> GetRooms();
        IQueryable<RoomEntity> GetRoomsByCity(string hotelCity);
        IQueryable<RoomEntity> GetRoomsByPinCode(string pinCode);
        IQueryable<RoomEntity> GetRoomsByPrice(decimal price);
        IQueryable<RoomEntity> GetRoomsByCategory(Category category);
        bool CreateRoom(RoomEntity room);
        bool CheckAvailability(int roomId, DateTime checkDate);
    }
}
