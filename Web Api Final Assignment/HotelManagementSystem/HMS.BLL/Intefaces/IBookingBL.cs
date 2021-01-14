using HMS.Entities;
using System;
using System.Linq;

namespace HMS.BLL.Intefaces
{
    public interface IBookingBL
    {
        BookingEntity GetBooking(int id);
        string BookRoom(int roomid, DateTime bookingDate);
        IQueryable<BookingEntity> GetBookings();
        string UpdateBooking(int bookingId, DateTime updatedDate);
        string UpdateBookingStatus(int id, Status bookingStatus);
        string DeleteBooking(int id);
    }
}
