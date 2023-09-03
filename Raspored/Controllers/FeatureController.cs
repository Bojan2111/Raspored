using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.Login;
using System.Threading.Tasks;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeatureController(IFeatureRepository featureRepository, UserManager<ApplicationUser> userManager)
        {
            _featureRepository = featureRepository;
            _userManager = userManager;
        }

        [HttpGet("/api/role-features")]
        [Authorize]
        public async Task<IActionResult> ListFeatures()
        {
            // Get the current user
            _ = await _userManager.GetUserAsync(User);

            // Check if the user has a role
            if (User.IsInRole("admin"))
            {
                var features = _featureRepository.GetFeaturesForRole("admin");
                return Ok(features);
            }
            else if (User.IsInRole("employee"))
            {
                var features = _featureRepository.GetFeaturesForRole("employee");
                return Ok(features);
            }
            else
            {
                return Unauthorized();
            }
        }
        //private readonly IFeatureRepository _featureRepository;

        //public FeatureController(IFeatureRepository featureRepository)
        //{
        //    _featureRepository = featureRepository;
        //}

        //[HttpGet]
        //[Route("/api/admin-features")]
        ////[Authorize(Roles = "admin")]
        //public IActionResult ListFeaturesForAdmin()
        //{
        //    var features = _featureRepository.GetFeaturesForRole("admin");
        //    return Ok(features);
        //}

        //[HttpGet]
        //[Route("/api/regular-features")]
        ////[Authorize(Roles = "zaposleni")]
        //public IActionResult ListFeaturesForEmployee()
        //{
        //    var features = _featureRepository.GetFeaturesForRole("zaposleni");
        //    return Ok(features);
        //}
    }
}
