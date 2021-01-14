using AutoMapper;
using HMS.DAL.Database;
using HMS.DAL.Interface;
using HMS.Entities;
using System;
using System.Linq;
using System.Data.Entity;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {

        private readonly HMSEntities _dbContext;
        private IMapper iMapper;
        private MapperConfiguration config;

        public RoomRepository(HMSEntities dbContext)
        {
            _dbContext = dbContext;

            config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Room, RoomEntity>();
                cfg.CreateMap<RoomEntity, Room>();
                cfg.CreateMap<Booking, BookingEntity>();
                cfg.CreateMap<BookingEntity, Booking>();

            });

            iMapper = config.CreateMapper();
        }

        public bool CheckAvailability(int roomId, DateTime checkDate)
        {

            try
            {

                var isValidRoomId = _dbContext.Rooms.Where(r => r.Id == roomId).Single();

                var noOfBookedRooms = _dbContext.Bookings.Where(b => b.Id == roomId && b.BookingDate == checkDate && b.status != Status.Deleted.ToString()).Count();

                if (noOfBookedRooms != 0)
                    return false;

                return true;

            } catch(Exception)
            {
                throw;
            }
        }

        public bool CreateRoom(RoomEntity room)
        {

            try
            {

                var _room = iMapper.Map<RoomEntity, Room>(room);

                _room.CreatedAt = DateTime.Now;
                _room.CreatedBy = "Admin";

                _dbContext.Rooms.Add(_room);
                _dbContext.SaveChanges();

                return true;

            } catch (Exception)
            {
                throw;
            }
        }

        public RoomEntity GetRoom(int id)
        {
            try
            {

                var room = _dbContext.Rooms.Include(b => b.Bookings).Where(r => r.Id == id).Single();

                if (room != null)
                {
                    RoomEntity _room = iMapper.Map<Room, RoomEntity>(room);

                    return _room;
                }

                return new RoomEntity();

            } catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<RoomEntity> GetRooms()
        {
            try
            {

                var rooms = _dbContext.Rooms.OrderBy(h => h.Price).Include(r => r.Bookings).Where(h => Convert.ToBoolean(h.IsActive)).Select(iMapper.Map<Room, RoomEntity>);
                return rooms.AsQueryable();

            } catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<RoomEntity> GetRoomsByCategory(Category category)
        {
            try
            {

                var rooms = _dbContext.Rooms.OrderBy(h => h.Price).Include(r => r.Bookings).Where(h => Convert.ToBoolean(h.IsActive) && h.Category == category.ToString()).Select(iMapper.Map<Room, RoomEntity>);
                return rooms.AsQueryable();

            } catch(Exception)
            {
                throw;
            }
        }

        public IQueryable<RoomEntity> GetRoomsByCity(string hotelCity)
        {
            try
            {

                var rooms = _dbContext.Rooms.OrderBy(h => h.Price).Include(r => r.Bookings).Where(h => Convert.ToBoolean(h.IsActive) && h.Hotel.City.Contains(hotelCity.ToLower())).Select(iMapper.Map<Room, RoomEntity>);
                return rooms.AsQueryable();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<RoomEntity> GetRoomsByPinCode(string pinCode)
        {
            try
            {
                var rooms = _dbContext.Rooms.OrderBy(h => h.Price).Include(r => r.Bookings).Where(h => Convert.ToBoolean(h.IsActive) && h.Hotel.PinCode.Contains(pinCode.ToLower())).Select(iMapper.Map<Room, RoomEntity>);
                return rooms.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<RoomEntity> GetRoomsByPrice(decimal price)
        {
            try
            {
                var rooms = _dbContext.Rooms.OrderBy(h => h.Price).Include(r => r.Bookings).Where(h => Convert.ToBoolean(h.IsActive) && h.Price == price).Select(iMapper.Map<Room, RoomEntity>);
                return rooms.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
