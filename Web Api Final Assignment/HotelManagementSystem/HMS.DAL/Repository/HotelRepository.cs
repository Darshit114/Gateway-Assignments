using AutoMapper;
using HMS.DAL.Database;
using HMS.DAL.Interface;
using HMS.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HMSEntities _dbContext;
        private IMapper iMapper;
        private MapperConfiguration config;

        public HotelRepository(HMSEntities dbContext)
        {
            _dbContext = dbContext;

            config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Hotel, HotelEntity>();
                cfg.CreateMap<HotelEntity, Hotel>();
                cfg.CreateMap<RoomEntity, Room>();
                cfg.CreateMap<Room, RoomEntity>();

            });

            iMapper = config.CreateMapper();
        }

        public bool CreateHotel(HotelEntity hotel)
        {
            try
            {
                var _hotel = iMapper.Map<HotelEntity, Hotel>(hotel);

                _hotel.CreatedeAt = DateTime.Now;
                _hotel.CreatedBy = "Admin";

                _dbContext.Hotels.Add(_hotel);
                _dbContext.SaveChanges();

                return true;

            } catch(Exception e)
            {
                throw e;
            }
        }

        public HotelEntity GetHotelById(int id)
        {
            try
            {

                if(id != -1)
                {
                    var hotel = _dbContext.Hotels.Find(id);

                    return iMapper.Map<Hotel, HotelEntity>(hotel);
                }

                return new HotelEntity();

            } catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<HotelEntity> GetHotels()
        {

            try
            {
                var hotels = _dbContext.Hotels.OrderBy(h => h.Name).Include(r => r.Rooms).Where(h => Convert.ToBoolean(h.IsActive)).Select(iMapper.Map<Hotel, HotelEntity>);

                return hotels.AsQueryable();

            } catch (Exception)
            {
                throw;
            }
        }
    }
}
