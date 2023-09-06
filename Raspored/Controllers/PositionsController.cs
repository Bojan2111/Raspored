using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;

        public PositionsController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }


        [HttpGet]
        [Route("/positions")]
        public IActionResult GetPositions()
        {
            return Ok(_positionRepository.GetAllPositions());
        }


        [HttpGet]
        [Route("/positions/{id}")]
        public IActionResult GetPosition(int id)
        {
            var position = _positionRepository.GetPosition(id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [Route("/positions")]
        public IActionResult PostPosition([FromBody] Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _positionRepository.AddPosition(position);

            return CreatedAtAction("GetPosition", new { id = position.Id }, position);
        }

        [HttpPut]
        [Route("/positions/{id}")]
        public IActionResult PutPosition(int id, Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != position.Id)
            {
                return BadRequest();
            }

            try
            {
                _positionRepository.UpdatePosition(position);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(position);
        }

        [HttpDelete]
        [Route("/positions/{id}")]
        public IActionResult DeletePosition(int id)
        {
            var position = _positionRepository.GetPosition(id);
            if (position == null)
            {
                return NotFound();
            }

            _positionRepository.DeletePosition(position);
            return NoContent();
        }
    }
}
