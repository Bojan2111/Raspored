using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RasporedTest.Controllers
{
    public class TeamMemberRoleControllerTest
    {
        [Fact]
        public void GetTeamMemberRoles_ReturnsCollection()
        {
            List<TeamMemberRole> teamMemberRoles = new List<TeamMemberRole>()
            {
                new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Foo",
                    Description = "Bar"
                },
                new TeamMemberRole()
                {
                    Id = 2,
                    Name = "Bar",
                    Description = "Foo"
                },
                new TeamMemberRole()
                {
                    Id = 3,
                    Name = "Foobar",
                    Description = "FUBAR"
                }
            };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetAllTeamMemberRoles()).Returns(teamMemberRoles.AsQueryable());

            var controller = new TeamMemberRoleController(mockRepository.Object);
            var actionResult = controller.GetTeamMemberRoles() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void GetTeamMemberRole_ValidId_ReturnsObject()
        {
            TeamMemberRole teamMemberRole = new() { Id = 1, Name = "Foo", Description = "Bar" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetTeamMemberRole(1)).Returns(teamMemberRole);

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.GetTeamMemberRole(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamMemberRole, actionResult.Value);
        }

        [Fact]
        public void GetTeamMemberRole_InvalidId_ReturnsNotFound()
        {
            var mockRepository = new Mock<ITeamMemberRoleRepository>();

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.GetTeamMemberRole(1) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeamMemberRole_ValidRequest_SetsLocationHeader()
        {
            TeamMemberRole teamMemberRole = new() { Id = 1, Name = "Foo", Description = "Bar" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.PostTeamMemberRole(teamMemberRole) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetTeamMemberRole", actionResult.ActionName);
            Assert.Equal(teamMemberRole.Id, actionResult.RouteValues["id"]);
            Assert.Equal(teamMemberRole, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeamMemberRole_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.AddTeamMemberRole(It.IsAny<TeamMemberRole>()))
                .Throws(new DataConflictException("A teamMemberRole with the same ID already exists."));

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.PostTeamMemberRole(new TeamMemberRole()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutTeamMemberRole_ValidRequest_ReturnsObject()
        {
            TeamMemberRole teamMemberRole = new() { Id = 1, Name = "Foo", Description = "Bar" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetTeamMemberRole(1)).Returns(teamMemberRole);

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.PutTeamMemberRole(1, teamMemberRole) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamMemberRole, actionResult.Value);
        }

        [Fact]
        public void PutTeamMemberRole_ValidRequest_ReturnsUpdatedObject()
        {
            TeamMemberRole initialTeamMemberRole = new() { Id = 1, Name = "Initial Name", Description = "Initial Description" };
            TeamMemberRole updatedTeamMemberRole = new() { Id = 1, Name = "Updated Name", Description = "Updated Description" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetTeamMemberRole(1)).Returns(initialTeamMemberRole);

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.PutTeamMemberRole(1, updatedTeamMemberRole);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as TeamMemberRole;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedTeamMemberRole.Name, updatedObject.Name);
        }

        [Fact]
        public void DeleteTeamMemberRole_ValidId_ReturnsNoContent()
        {
            TeamMemberRole teamMemberRole = new() { Id = 1, Name = "Foo", Description = "Bar" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetTeamMemberRole(1)).Returns(teamMemberRole);

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.DeleteTeamMemberRole(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeleteTeamMemberRole_InvalidId_ReturnsNotFound()
        {
            TeamMemberRole teamMemberRole = new() { Id = 1, Name = "Foo", Description = "Bar" };

            var mockRepository = new Mock<ITeamMemberRoleRepository>();
            mockRepository.Setup(x => x.GetTeamMemberRole(1)).Returns(teamMemberRole);

            var controller = new TeamMemberRoleController(mockRepository.Object);

            var actionResult = controller.DeleteTeamMemberRole(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
