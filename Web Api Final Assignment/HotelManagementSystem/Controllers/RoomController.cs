using HMS.BLL.Intefaces;
using HMS.Entities;
using HotelManagementSystem.Helper;
using System;
using System.Linq;
using System.Web.Http;

namespace HotelManagementSystem.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/v1/Room")]
    public class RoomController : ApiController
    {
        private readonly IRoomBL _room;

        public RoomController(IRoomBL room)
        {
            _room = room;
        }

        // GET: api/v1/Room/GetRooms
        [Route("GetRooms")]
        [HttpGet]
        public IHttpActionResult GetRooms()
        {
            var rooms = _room.GetRooms();

            if (!rooms.Any())
                return NotFound();

            return Ok(rooms);
        }

        // GET: api/v1/Room/GetRoomByCity/rajkot
        [Route("GetRoomByCity/{hotelCity:alpha}")]
        [HttpGet]
        public IHttpActionResult GetRoomsByCity(string hotelCity)
        {
            var rooms = _room.GetRoomsByCity(hotelCity);

            if (!rooms.Any()) return NotFound();

            return Ok(rooms);
        }

        // GET: api/v1/Room/GetRoomByPin/360311
        [Route("api/rooms/pincode/{pinCode:length(6,10)}")]
        public IHttpActionResult GetRoomsByPinCode(string pinCode)
        {
            var rooms = _room.GetRoomsByPinCode(pinCode);

            if (!rooms.Any()) return NotFound();

            return Ok(rooms);
        }

        //GET: api/v1/Room/GetRoomByPrice/500
        [Route("GetRoomByPrice/{price:decimal}")]
        public IHttpActionResult GetRoomsByPrice(decimal price)
        {
            var rooms = _room.GetRoomsByPrice(price);

            if (!rooms.Any()) return NotFound();

            return Ok(rooms);
        }

        // GET: api/v1/Room/GetRoomByCategory/1
        [Route("GetRoomByCategory/{category:int}")]
        public IHttpActionResult GetRoomsByCategory(Category category)
        {
            var rooms = _room.GetRoomsByCategory(category);

            if (!rooms.Any()) return NotFound();

            return Ok(rooms);
        }

        // GET: api/v1/Room/CheckRoom
        [Route("CheckRoom/{roomId:int}/{date:datetime}")]
        [HttpGet]
        public IHttpActionResult CheckRoom(int roomId, DateTime date)
        {
            try
            {
                var res = _room.CheckAvailability(roomId, date);

                if (res)
                    return Ok("Available");
                else
                    return Ok("Not Available");

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // POST api/v1/Room/Create
        [Route("Create")]
        public IHttpActionResult PostRoom(RoomEntity room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_room.CreateRoom(room));
        }
    }
}
