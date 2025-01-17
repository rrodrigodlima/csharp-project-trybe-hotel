using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {
            // Chama o método GetHotels() do repositório
            var hotels = _repository.GetHotels();

            return Ok(hotels);
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            // Chame o método AddHotel() do repositório para inserir o hotel
            var addedHotel = _repository.AddHotel(hotel);

            return CreatedAtAction(nameof(GetHotels), addedHotel);
        }


    }
}