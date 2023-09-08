using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using Raspored.Repositories;
using System;
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
        [Route("/shifts")]
        public IActionResult GetShifts()
        {
            return Ok(_shiftRepository.GetAllShifts());
        }

        [HttpGet]
        [Route("/shifts/{id}")]
        public IActionResult GetShift(int id)
        {
            var shift = _shiftRepository.GetShift(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }

        [HttpPost]
        [Route("/shifts")]
        public IActionResult PostShift([FromBody] Shift shift)
        {
            try
            {
                if (_shiftRepository.IsConflictDetected(shift.Id))
                {
                    throw new DataConflictException("A shift with the same ID already exists.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _shiftRepository.AddShift(shift);

                return CreatedAtAction("GetShift", new { id = shift.Id }, shift);
            }
            catch (DataConflictException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
        }

        [HttpPut]
        [Route("/shifts/{id}")]
        public IActionResult PutShift(int id, Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shift.Id)
            {
                return BadRequest();
            }

            try
            {
                _shiftRepository.UpdateShift(shift);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(shift);
        }

        [HttpDelete]
        [Route("/shifts/{id}")]
        public IActionResult DeleteShift(int id)
        {
            var shift = _shiftRepository.GetShiftById(id);
            if (shift == null)
            {
                return NotFound();
            }

            _shiftRepository.DeleteShift(shift);
            return NoContent();
        }
    }
}
