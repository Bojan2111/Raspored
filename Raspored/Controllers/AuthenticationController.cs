﻿using Raspored.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userProfile = new UserProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                YearOfEmployment = user.YearOfEmployment,
                LicenseNumber = user.LicenseNumber,
                ContractTypeId = (int)user.ContractTypeId,
                PositionId = (int)user.PositionId
            };

            return Ok(userProfile);
        }

        [HttpGet]
        [Route("/users/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userProfile = new UserProfileDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                YearOfEmployment = user.YearOfEmployment,
                LicenseNumber = user.LicenseNumber,
                ContractTypeId = (int)user.ContractTypeId,
                PositionId = (int)user.PositionId
            };

            return Ok(userProfile);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("/register")]
        public async Task<IActionResult> Register(RegistrationDTO model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                UserName = model.UserName,
                Email = model.Email,
                YearOfEmployment = model.YearOfEmployment,
                LicenseNumber = model.LicenseNumber,
                ContractTypeId = model.ContractTypeId,
                PositionId = model.PositionId
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);

                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Login parameters invalid.");
            }
            var user = _userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (user != null && _userManager.CheckPasswordAsync(user, model.Password).GetAwaiter().GetResult())
            {
                var roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(2), // AddDays(7) - valid for a week
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new TokenDTO()
                {
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPut]
        [Route("/users/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserProfileDTO updatedUserData)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            user.FirstName = updatedUserData.FirstName;
            user.LastName = updatedUserData.LastName;
            user.DateOfBirth = updatedUserData.DateOfBirth;
            user.UserName = updatedUserData.UserName;
            user.Email = updatedUserData.Email;
            user.YearOfEmployment = updatedUserData.YearOfEmployment;
            user.LicenseNumber = updatedUserData.LicenseNumber;
            user.ContractTypeId = updatedUserData.ContractTypeId;
            user.PositionId = updatedUserData.PositionId;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok("User updated successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpDelete]
        [Route("/users/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Deleted = true;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
