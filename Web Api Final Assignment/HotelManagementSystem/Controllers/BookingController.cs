using HMS.BLL.Intefaces;
using HMS.Entities;
using HotelManagementSystem.Helper;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace HotelManagementSystem.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/v1/Booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingBL _booking;

        public BookingController(IBookingBL booking)
        {
            _booking = booking;
        }
        
        // GET api/v1/Booking/GetBooking/1
        [ResponseType(typeof(BookingEntity))]
        public IHttpActionResult GetBooking(int id)
        {
            var booking = _booking.GetBooking(id);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        // GET api/v1/Booking/GetBookings
        [Route("GetBookings")]
        [HttpGet]
        public IHttpActionResult GetBookings()
        {
            var bookings = _booking.GetBookings();

            if (!bookings.Any())
                return NotFound();

            return Ok(bookings);
        }

        // PUT api/v1/Booking/UpdateBooking
        [Route("UpdateBooking/{bookingId:int}/{updatedDate:datetime}")]
        [HttpPut]
        public IHttpActionResult UpdateBookingDate(int bookingId, DateTime updatedDate)
        {
            string result = _booking.UpdateBooking(bookingId, updatedDate);

            if (result == "Failure")
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT api/v1/Booking/GetBooking/1
        [Route("UpdateStatus/{bookingId:int}/{bookingStatus}")]
        [HttpPut]
        public IHttpActionResult UpdateBookingStatus(int bookingId, Status bookingStatus)
        {
            if (!(bookingStatus == Status.Definitive || bookingStatus == Status.Cancelled)) 
            {
                return BadRequest("Invalid booking status.");
            }

            string result = _booking.UpdateBookingStatus(bookingId, bookingStatus);


            if (result == "Failure")
            {
                return NotFound();
            }

            return Ok(result);

        }

        // POST api/v1/Booking/PostBooking
        [Route("api/booking/{roomId:int}/{bookingDate:datetime}")]
        [ResponseType(typeof(BookingEntity))]
        public IHttpActionResult PostBooking(int roomId, DateTime bookingDate)
        {
            var res = _booking.BookRoom(roomId, bookingDate);

            if (res == "Failure")
                return InternalServerError();

            return Ok(res);
        }

        // DELETE api/v1/Booking/Delete/1
        [Route("Delete/{bookingId:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int bookingId)
        {
            string result = _booking.DeleteBooking(bookingId);

            if (result == "Failure")
            {
                return NotFound();
            }

            if (result == "Successfull")
            {
                return Ok(result);
            }

            return InternalServerError();
        }

    }
}
