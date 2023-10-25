using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId)
        {
            // Chama o método GetRooms() do repositório para obter a lista de quartos
            var rooms = _repository.GetRooms(HotelId);

            return Ok(rooms);
        }

        // 7. Desenvolva o endpoint POST /room
        [HttpPost]
        public IActionResult PostRoom([FromBody] Room room)
        {

            // Chame o método AddRoom() do repositório para inserir o quarto
            var addedRoom = _repository.AddRoom(room);

            return CreatedAtAction(nameof(GetRoom), addedRoom);
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        [HttpDelete("{RoomId}")]
        public IActionResult Delete(int RoomId)
        {
            // Chame o método DeleteRoom() do repositório para excluir o quarto
            _repository.DeleteRoom(RoomId);

            return NoContent();
        }
    }
}