using HMS.BLL.Intefaces;
using HMS.DAL.Interface;
using HMS.Entities;
using System;
using System.Linq;

namespace HMS.BLL
{
    public class BookingBL : IBookingBL
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingBL(IBookingRepository booking)
        {
            _bookingRepo = booking;
        }

        public string BookRoom(int roomid, DateTime bookingDate)
        {
            var res = _bookingRepo.BookRoom(roomid, bookingDate);

            if (res)
                return "Successfull";

            return "Failure";
        }

        public string DeleteBooking(int id)
        {
            var res = _bookingRepo.DeleteBooking(id);

            if (res)
                return "Successfull";

            return "Failure";
        }

        public BookingEntity GetBooking(int id)
        {
            return _bookingRepo.GetBooking(id);
        }

        public IQueryable<BookingEntity> GetBookings()
        {
            return _bookingRepo.GetBookings();
        }

        public string UpdateBooking(int bookingId, DateTime updatedDate)
        {
            var res = _bookingRepo.UpdateBooking(bookingId, updatedDate);

            if (res)
                return "Successfull";

            return "Failure";
        }

        public string UpdateBookingStatus(int id, Status bookingStatus)
        {
            var res = _bookingRepo.UpdateBookingStatus(id, bookingStatus);

            if (res)
                return "Successfull";

            return "Failure";
        }
    }
}
