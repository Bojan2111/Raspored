using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Repositories;

namespace Raspored.Controllers
{
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

            return Ok();
        }

        [HttpPost]
        [Route("/contract-types")]
        public IActionResult PostContractType([FromBody] ContractType contractType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contractTypeRepository.AddContractType(contractType);

            return CreatedAtAction("GetContractType", new { id = contractType.Id }, contractType);
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
