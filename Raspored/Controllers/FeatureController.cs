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

        [HttpGet("/role-features")]
        [Authorize]
        public async Task<IActionResult> ListFeatures()
        {
            _ = await _userManager.GetUserAsync(User);

            if (User.IsInRole("admin"))
            {
                var features = _featureRepository.GetFeaturesForRole("admin");
                return Ok(features);
            }
            else if (User.IsInRole("zaposleni"))
            {
                var features = _featureRepository.GetFeaturesForRole("zaposleni");
                return Ok(features);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
