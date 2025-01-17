using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        // 2. Desenvolva o endpoint GET /city
        [HttpGet]
        public IActionResult GetCities()
        {
            // Chama o método GetCities() do repositório
            var cities = _repository.GetCities();

            return Ok(cities);
        }

        // 3. Desenvolva o endpoint POST /city
        [HttpPost]
        public IActionResult PostCity([FromBody] City city)
        {
            // Chame o método AddCity() do repositório para inserir a cidade
            var addedCity = _repository.AddCity(city);

            return CreatedAtAction(nameof(GetCities), addedCity);
        }
    }
}