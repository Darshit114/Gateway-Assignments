using HMS.Entities;
using System;
using System.Linq;

namespace HMS.DAL.Interface
{
    public interface IBookingRepository
    {
        BookingEntity GetBooking(int id);
        bool BookRoom(int roomId, DateTime date);
        IQueryable<BookingEntity> GetBookings();
        bool UpdateBooking(int bookingId, DateTime updatedDate);
        bool UpdateBookingStatus(int id, Status bookingStatus);
        bool DeleteBooking(int id);
    }
}
