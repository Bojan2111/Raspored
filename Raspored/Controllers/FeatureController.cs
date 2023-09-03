using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.Login;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        [HttpGet]
        [Route("/api/admin-features")]
        //[Authorize(Roles = "admin")]
        public IActionResult ListFeaturesForAdmin()
        {
            var features = _featureRepository.GetFeaturesForRole("admin");
            return Ok(features);
        }

        [HttpGet]
        [Route("/api/regular-features")]
        //[Authorize(Roles = "zaposleni")]
        public IActionResult ListFeaturesForEmployee()
        {
            var features = _featureRepository.GetFeaturesForRole("zaposleni");
            return Ok(features);
        }
    }
}
