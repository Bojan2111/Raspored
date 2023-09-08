using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using Raspored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper.QueryableExtensions;
using Raspored.Models.Login;

namespace RasporedTest.Controllers
{
    public class TeamMemberControllerTest
    {
        [Fact]
        public void GetTeamMembers_ReturnsDTOCollection()
        {
            var teamMembers = new List<TeamMember>()
            {
                new TeamMember()
                {
                    Id = 1,
                    UserId = "Fakeurserid123",
                    User = new ApplicationUser()
                    {
                        Id = "Fakeurserid123",
                        FirstName = "Test",
                        LastName = "Tester"
                    },
                    TeamId = 1,
                    Team = new Team()
                    {
                        Id = 1,
                        Name = "Test team"
                    },
                    TeamMemberRoleId = 1,
                    TeamMemberRole = new TeamMemberRole()
                    {
                        Id = 1,
                        Name = "Test role",
                        Description = "Test role description"
                    }
                },
                new TeamMember()
                {
                    Id = 2,
                    UserId = "Fakeurserid456",
                    User = new ApplicationUser()
                    {
                        Id = "Fakeurserid456",
                        FirstName = "Test",
                        LastName = "Testing"
                    },
                    TeamId = 2,
                    Team = new Team()
                    {
                        Id = 2,
                        Name = "Testing team"
                    },
                    TeamMemberRoleId = 1,
                    TeamMemberRole = new TeamMemberRole()
                    {
                        Id = 1,
                        Name = "Test role",
                        Description = "Test role description"
                    }
                }
            };

            var teamMembersDTO = new List<TeamMemberDTO>()
            {
                new TeamMemberDTO()
                {
                    Id = 1,
                    Name = "Tester Test",
                    TeamName = "Test team",
                    Role = "Test role"
                },
                new TeamMemberDTO()
                {
                    Id = 2,
                    Name = "Testing Test",
                    TeamName = "Testing team",
                    Role = "Test role"
                }
            };
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetAllTeamMembers()).Returns(teamMembers.AsQueryable());

            var controller = new TeamMemberController(mockRepository.Object, mapper);
            var actionResult = controller.GetMembers() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
        }

        [Fact]
        public void GetTeamMemberDTO_ValidId_ReturnsObject()
        {
            var teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var teamMemberDTO = new TeamMemberDTO()
            {
                Id = 1,
                Name = "Test Tester",
                TeamName = "Test team",
                Role = "Test role"
            };

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMember(1)).Returns(teamMemberDTO);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamMemberController(mockRepository.Object, mapper);
            var actionResult = controller.GetTeamMember(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamMemberDTO, actionResult.Value);
        }
        [Fact]
        public void GetTeamMemberDTO_InvalidId_ReturnsNotFound()
        {
            var teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var teamMemberDTO = new TeamMemberDTO()
            {
                Id = 1,
                Name = "Test Tester",
                TeamName = "Test team",
                Role = "Test role"
            };

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMember(1)).Returns(teamMemberDTO);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamMemberController(mockRepository.Object, mapper);
            var actionResult = controller.GetTeamMember(123) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeamMember_ValidRequest_SetsLocationHeader()
        {
            TeamMember teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var mockRepository = new Mock<ITeamMemberRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.PostTeamMember(teamMember) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetTeamMember", actionResult.ActionName);
            Assert.Equal(teamMember.Id, actionResult.RouteValues["id"]);
            Assert.Equal(teamMember, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostTeamMember_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.AddTeamMember(It.IsAny<TeamMember>()))
                .Throws(new DataConflictException("A teamMember with the same ID already exists."));

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.PostTeamMember(new TeamMember()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutTeamMember_ValidRequest_ReturnsObject()
        {
            TeamMember teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMemberById(1)).Returns(teamMember);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.PutTeamMember(1, teamMember) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(teamMember, actionResult.Value);
        }

        [Fact]
        public void PutTeamMember_ValidRequest_ReturnsUpdatedObject()
        {
            TeamMember initialTeamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };
            TeamMember updatedTeamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 2,
                Team = new Team()
                {
                    Id = 2,
                    Name = "Testing team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMemberById(1)).Returns(initialTeamMember);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.PutTeamMember(1, updatedTeamMember);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as TeamMember;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedTeamMember.Id, updatedObject.Id);
        }

        [Fact]
        public void DeleteTeamMember_ValidId_ReturnsNoContent()
        {
            TeamMember teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMemberById(1)).Returns(teamMember);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteTeamMember(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeleteTeamMember_InvalidId_ReturnsNotFound()
        {
            TeamMember teamMember = new TeamMember()
            {
                Id = 1,
                UserId = "Fakeurserid123",
                User = new ApplicationUser()
                {
                    Id = "Fakeurserid123",
                    FirstName = "Test",
                    LastName = "Tester"
                },
                TeamId = 1,
                Team = new Team()
                {
                    Id = 1,
                    Name = "Test team"
                },
                TeamMemberRoleId = 1,
                TeamMemberRole = new TeamMemberRole()
                {
                    Id = 1,
                    Name = "Test role",
                    Description = "Test role description"
                }
            };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TeamMemberProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<ITeamMemberRepository>();
            mockRepository.Setup(x => x.GetTeamMemberById(1)).Returns(teamMember);

            var controller = new TeamMemberController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteTeamMember(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
