using HMS.BLL.Intefaces;
using HMS.Entities;
using HotelManagementSystem.Helper;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace HotelManagementSystem.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/v1/Hotel")]
    public class HotelController : ApiController
    {
        private readonly IHotelBL _hotel;

        public HotelController(IHotelBL hotel)
        {
            _hotel = hotel;
        }

        // GET api/v1/Hotel/GetHotels
        [Route("GetHotels")]
        [HttpGet]
        public IHttpActionResult GetHotels()
        {
            var hotels = _hotel.GetHotels();

            if (!hotels.Any())
                return NotFound();

            return Ok(hotels);
        }

        // GET api/v1/Hotel/GetHotel/1
        [Route("GetHotel/{id:int}")]
        [ResponseType(typeof(HotelEntity))]
        public IHttpActionResult Get(int id)
        {
            var hotel = _hotel.GetHotel(id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        // POST api/v1/Hotel/PostHotel
        [Route("PostHotel")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] HotelEntity hotel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            return Ok(_hotel.CreateHotel(hotel));
        }

    }
}
