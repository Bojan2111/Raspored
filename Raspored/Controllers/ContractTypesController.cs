using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;

namespace Raspored.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypesController : ControllerBase
    {
        private readonly IContractTypeRepository _contractTypeRepository;


        public ContractTypesController(IContractTypeRepository contractTypeRepository)
        {
            _contractTypeRepository = contractTypeRepository;
        }


        [HttpGet]
        [Route("/contract-types")]
        public IActionResult GetContractTypes()
        {
            return Ok(_contractTypeRepository.GetAllContractTypes());
        }


        [HttpGet]
        [Route("/contract-types/{id}")]
        public IActionResult GetContractType(int id)
        {
            var contractType = _contractTypeRepository.GetContractType(id);

            if (contractType == null)
            {
                return NotFound();
            }

            return Ok(contractType);
        }

        [HttpPost]
        [Route("/contract-types")]
        public IActionResult PostContractType([FromBody] ContractType contractType)
        {
            try
            {
                if (_contractTypeRepository.IsConflictDetected(contractType.Id))
                {
                    throw new DataConflictException("A contract type with the same ID already exists.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _contractTypeRepository.AddContractType(contractType);

                return CreatedAtAction("GetContractType", new { id = contractType.Id }, contractType);
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
        [Route("/contract-types/{id}")]
        public IActionResult PutContractType(int id, ContractType contractType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contractType.Id)
            {
                return BadRequest();
            }

            try
            {
                _contractTypeRepository.UpdateContractType(contractType);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(contractType);
        }

        [HttpDelete]
        [Route("/contract-types/{id}")]
        public IActionResult DeleteContractType(int id)
        {
            var contractType = _contractTypeRepository.GetContractType(id);
            if (contractType == null)
            {
                return NotFound();
            }

            _contractTypeRepository.DeleteContractType(contractType);
            return NoContent();
        }
    }
}
