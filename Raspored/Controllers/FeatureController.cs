using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models.Login;

namespace Raspored.Controllers
{
    [Authorize]
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

        [HttpGet("/role-features/{featureTypeId}")]
        public IActionResult ListFeatures(int featureTypeId)
        {
            _ = _userManager.GetUserAsync(User);

            if (User.IsInRole("admin"))
            {
                var features = _featureRepository.GetFeaturesForRole("admin", featureTypeId);
                return Ok(features);
            }
            else if (User.IsInRole("zaposleni"))
            {
                var features = _featureRepository.GetFeaturesForRole("zaposleni", featureTypeId);
                return Ok(features);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
