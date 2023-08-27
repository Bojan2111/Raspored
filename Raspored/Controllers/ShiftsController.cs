using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public ShiftsController(IShiftRepository shiftRepository, IMapper mapper)
        {
            _shiftRepository = shiftRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/shifts")]
        public IActionResult GetShifts()
        {
            return Ok(_shiftRepository.GetAllShifts());
        }

        [HttpGet]
        [Route("/api/shifts/{id}")]
        public IActionResult GetShift(int id)
        {
            var shift = _shiftRepository.GetShift(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }
    }
}
