using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using Raspored.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RasporedTest.Controllers
{
    public class TeamsControllerTest
    {
        [Fact]
        public void GetTeams_ReturnsDTOCollection()
        {
            var teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "Test"
                },
                new Team()
                {
                    Id = 2,
                    Name = "Tester"
                }
            };

            var teamsDTO = new List<TeamDTO>()
            {
                new TeamDTO()
                {
                    Id = 1,
                    Name = "Test",
                    TeamMembers = new List<TeamMemberDTO>()
                    {
                        new TeamMemberDTO()
                        {
                            Id = 1,
                            Name = "Tester Test",
                            TeamName = "Test",
                            Role = "Tester"
                        },
                        new TeamMemberDTO()
                        {
                            Id = 2,
                            Name = "Testing Test",
                            TeamName = "Test",
                            Role = "Tester"
                        }
                    }
                },
                new TeamDTO()
                {
                    Id = 2,
                    Name = "Tester",
                    TeamMembers = new List<TeamMemberDTO>()
                    {
                        new TeamMemberDTO()
                        {
                            Id = 3,
                            Name = "Tester Testing",
                            TeamName = "Tester",
                            Role = "Test"
                        },
                        new TeamMemberDTO()
                        {
                            Id = 4,
                            Name = "Testing Tester",
                            TeamName = "Tester",
                            Role = "Test"
                        }
                    }
                }
            };
            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeamsWithMembers()).Returns(teamsDTO.AsQueryable());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeamsWithMembers() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamsDTO, actionResult.Value);
        }

        [Fact]
        public void GetTeamDTO_ValidId_ReturnsObject()
        {
            var team = new Team()
            {
                Id = 1,
                Name = "Test"
            };

            var teamDTO = new TeamDTO()
            {
                Id = 1,
                Name = "Test",
                TeamMembers = new List<TeamMemberDTO>()
                    {
                        new TeamMemberDTO()
                        {
                            Id = 1,
                            Name = "Tester Test",
                            TeamName = "Test",
                            Role = "Tester"
                        },
                        new TeamMemberDTO()
                        {
                            Id = 2,
                            Name = "Testing Test",
                            TeamName = "Test",
                            Role = "Tester"
                        }
                    }
            };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeamWithMembers(1)).Returns(teamDTO);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeamWithMembers(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamDTO, actionResult.Value);
        }
        [Fact]
        public void GetTeamDTO_InvalidId_ReturnsNotFound()
        {
            var team = new Team()
            {
                Id = 1,
                Name = "Test"
            };

            var teamDTO = new TeamDTO()
            {
                Id = 1,
                Name = "Test",
                TeamMembers = new List<TeamMemberDTO>()
                    {
                        new TeamMemberDTO()
                        {
                            Id = 1,
                            Name = "Tester Test",
                            TeamName = "Test",
                            Role = "Tester"
                        },
                        new TeamMemberDTO()
                        {
                            Id = 2,
                            Name = "Testing Test",
                            TeamName = "Test",
                            Role = "Tester"
                        }
                    }
            };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeamWithMembers(1)).Returns(teamDTO);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeamWithMembers(123) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void GetTeams_ReturnsCollection()
        {
            var teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "Test"
                },
                new Team()
                {
                    Id = 2,
                    Name = "Tester"
                }
            };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetAllTeams()).Returns(teams.AsQueryable());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeams() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teams, actionResult.Value);
        }

        [Fact]
        public void GetTeam_ValidId_ReturnsObject()
        {
            var team = new Team()
            {
                Id = 1,
                Name = "Test"
            };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(team);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeam(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(team, actionResult.Value);
        }
        [Fact]
        public void GetTeam_InvalidId_ReturnsNotFound()
        {
            var team = new Team()
            {
                Id = 1,
                Name = "Test"
            };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(team);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.GetTeam(123) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeam_ValidRequest_SetsLocationHeader()
        {
            Team team = new() {
                Id = 1,
                Name = "Test"
            };

            var mockRepository = new Mock<ITeamRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.PostTeam(team) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetTeam", actionResult.ActionName);
            Assert.Equal(team.Id, actionResult.RouteValues["id"]);
            Assert.Equal(team, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeam_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.AddTeam(It.IsAny<Team>()))
                .Throws(new DataConflictException("A team with the same ID already exists."));

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.PostTeam(new Team()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutTeam_ValidRequest_ReturnsObject()
        {
            Team team = new() { Id = 1, Name = "Test" };

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(team);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.PutTeam(1, team) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(team, actionResult.Value);
        }

        [Fact]
        public void PutTeam_ValidRequest_ReturnsUpdatedObject()
        {
            Team initialTeam = new() { Id = 1, Name = "Test" };
            Team updatedTeam = new() { Id = 1, Name = "Testing" };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(initialTeam);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.PutTeam(1, updatedTeam);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as Team;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedTeam.Name, updatedObject.Name);
        }

        [Fact]
        public void DeleteTeam_ValidId_ReturnsNoContent()
        {
            Team team = new() { Id = 1, Name = "Test" };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(team);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteTeam(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeleteTeam_InvalidId_ReturnsNotFound()
        {
            Team team = new() { Id = 1, Name = "Test" };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamRepository>();
            mockRepository.Setup(x => x.GetTeam(1)).Returns(team);

            var controller = new TeamsController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteTeam(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
