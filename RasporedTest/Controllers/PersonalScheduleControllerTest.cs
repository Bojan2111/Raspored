using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.Interfaces;
using Raspored.Models.DTOs;
using System;
using System.Collections.Generic;
using Xunit;

namespace RasporedTest.Controllers
{
    public class PersonalScheduleControllerTest
    {
        [Fact]
        public void GetPersonalSchedule_ValidId_ReturnsObject()
        {
            PersonalSchedule personalSchedule = new PersonalSchedule()
            {
                TeamMemberId = 1,
                TeamName = "Tim 1",
                FirstName = "Petar",
                LastName = "Petrovic",
                TeamMemberRoleName = "VT",
                TeamMemberRoleDescription = "Voda smene",
                MonthName = "AUGUST",
                Shifts = new List<ShiftDTO>()
                {
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 1),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 2),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 6),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 7),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 11),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 12),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 16),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 17),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 21),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 22),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 26),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 27),
                        TeamMemberId = 1,
                        ShiftTypeName = "N",
                        ShiftTypeDescription = "Nocna smena - od 19h do 07h",
                    },
                    new ShiftDTO()
                    {
                        ShiftDate = new DateTime(2023, 8, 31),
                        TeamMemberId = 1,
                        ShiftTypeName = "D",
                        ShiftTypeDescription = "Dnevna smena - od 07h do 19h",
                    }
                }
            };

            var mockRepository = new Mock<IPersonalScheduleRepository>();
            mockRepository.Setup(x => x.GetPersonalSchedule(1, 8)).Returns(personalSchedule);

            var controller = new PersonalScheduleController(mockRepository.Object);

            var actionResult = controller.GetPersonalSchedule(1, 8) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(personalSchedule, actionResult.Value);
        }

        [Fact]
        public void GetPersonalSchedule_InvalidId_ReturnsNotFound()
        {
            var mockRepository = new Mock<IPersonalScheduleRepository>();

            var controller = new PersonalScheduleController(mockRepository.Object);

            var actionResult = controller.GetPersonalSchedule(112, 4) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
