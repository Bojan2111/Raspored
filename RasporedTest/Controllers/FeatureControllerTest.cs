using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.Login;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace RasporedTest.Controllers
{
    public class FeatureControllerTest
    {
        [Fact]
        public void ListFeatures_ForAdminRole_ReturnsCollection()
        {
            List<Feature> features = new List<Feature>()
            {
                new Feature()
                {
                    Id = 1,
                    Name = "Foo",
                    Description = "Bar",
                },
                new Feature()
                {
                    Id = 2,
                    Name = "Bar",
                    Description = "Foo",
                },
                new Feature()
                {
                    Id = 3,
                    Name = "Foobar",
                    Description = "FUBAR",
                }
            };

            var mockRepository = new Mock<IFeatureRepository>();
            mockRepository.Setup(x => x.GetFeaturesForRole("admin", 1)).Returns(features.AsQueryable());

            var userRoles = new List<string> { "admin" };

            var mockUserManager = MockUserManager<ApplicationUser>(userRoles);
            var controller = new FeatureController(mockRepository.Object, mockUserManager.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "asdf"),
                new Claim(ClaimTypes.Role, "admin"),
            }, "mock"));

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            var actionResult = controller.ListFeatures(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
        }

        private Mock<UserManager<TUser>> MockUserManager<TUser>(IEnumerable<string> roles) where TUser : class
        {
            var userStore = new Mock<IUserStore<TUser>>();
            var userManager = new Mock<UserManager<TUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            userManager.Setup(x => x.GetRolesAsync(It.IsAny<TUser>()))
                       .ReturnsAsync(roles.ToList());

            return userManager;
        }
    }
}
