using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using Raspored.Models.Login;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("/role-features/")]
        public IActionResult ListFeatures()
        {
            _ = _userManager.GetUserAsync(User);
            var features = new List<FeaturesDTO>();

            if (User.IsInRole("admin"))
            {
                features = _featureRepository.GetFeaturesForRole("admin").ToList();
            }
            else if (User.IsInRole("zaposleni"))
            {
                features = _featureRepository.GetFeaturesForRole("zaposleni").ToList();
            }
            else
            {
                return Unauthorized();
            }
            var menuFeatureDictionary = features
                .GroupBy(feature => feature.Menu)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(feature => new Feature
                    {
                        Id = feature.Id,
                        Name = feature.Name,
                        Description = feature.Description
                    })
                );

            return Ok(menuFeatureDictionary);
        }
    }
}
