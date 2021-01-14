using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMS.DAL.Database;
using HMS.DAL.Interface;
using HMS.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HMSEntities _dbContext;
        private IMapper iMapper;
        private MapperConfiguration config;

        public BookingRepository(HMSEntities dbContext)
        {
            _dbContext = dbContext;

            config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Booking, BookingEntity>();
                cfg.CreateMap<BookingEntity, Booking>();

            });

            iMapper = config.CreateMapper();
        }

        public bool BookRoom(int roomId, DateTime date)
        {
            try
            {

                var isValidRoomId = _dbContext.Rooms.Where(b => b.Id == roomId).Single(); 

        
                var bookingCount = _dbContext.Bookings.Where(b => b.RoomId == roomId && b.BookingDate == date && b.status != Status.Deleted.ToString()).Count();

                if (bookingCount != 0)
                    return false;

                var booking = new Booking();

                booking.RoomId = roomId;
                booking.BookingDate = date;
                booking.status = Status.Optional.ToString();

                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();

            } catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool DeleteBooking(int id)
        {
            try
            {
                var bookingInDb = _dbContext.Bookings.SingleOrDefault(b => b.Id == id);

                if (bookingInDb == null)
                {
                    return false;
                }

                bookingInDb.status = Status.Deleted.ToString();

                _dbContext.Entry(bookingInDb).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public BookingEntity GetBooking(int id)
        {
            try
            {
                var booking = _dbContext.Bookings.Find(id);

                if (booking != null)
                {
                    return iMapper.Map<Booking, BookingEntity>(booking);
                }

                return new BookingEntity();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<BookingEntity> GetBookings()
        {
            try
            {
                return _dbContext.Bookings.ToList().AsQueryable().ProjectTo<BookingEntity>(config);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateBooking(int bookingId, DateTime updatedDate)
        {
            try
            {
                var bookingInDb = _dbContext.Bookings.SingleOrDefault(b => b.Id == bookingId);

                if (bookingInDb == null)
                {
                    return false;
                }

                if (bookingInDb.status == Status.Deleted.ToString())
                {
                    return false;
                }

                //check if there are bookings already
                var bookingCount = _dbContext.Bookings.Where(b => b.Id == bookingId && b.BookingDate == updatedDate && b.status != Status.Deleted.ToString()).Count();

                if (bookingCount != 0)
                    return false;

                bookingInDb.BookingDate = updatedDate;
                _dbContext.Entry(bookingInDb).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool UpdateBookingStatus(int id, Status bookingStatus)
        {
            try
            {
                var bookingInDb = _dbContext.Bookings.SingleOrDefault(b => b.Id == id);

                if (bookingInDb == null)
                {
                    return false;
                }

                if (bookingInDb.status == Status.Deleted.ToString())
                    return false;

                bookingInDb.status = bookingStatus.ToString();

                _dbContext.Entry(bookingInDb).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
