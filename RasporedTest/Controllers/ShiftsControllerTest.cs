using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Raspored.Controllers;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RasporedTest.Controllers
{
    public class ShiftsControllerTest
    {
        //private readonly IConfiguration _configuration;
        //private readonly Mock<IShiftRepository>() _shiftRepository;
        //private readonly IMapper _mapper;
        //public ShiftsControllerTest(IConfiguration configuration, IShiftRepository shiftRepository, IMapper mapper)
        //{
        //    _configuration = configuration;
        //    _shiftRepository = shiftRepository;
        //    _mapper = mapper;
        //}

        [Fact]
        public void GetShifts_ReturnsDTOCollection()
        {
            //var config = new ConfigurationBuilder(); // Pogledaj dokumentaciju pa primeni za autorizaciju
            var shifts = new List<Shift>()
            {
                new Shift()
                {
                    Id = 1,
                    Date = new DateTime(2023, 8, 12),
                    ShiftTypeId = 1,
                    TeamMemberId = 1,
                },
                new Shift()
                {
                    Id = 2,
                    Date = new DateTime(2023, 8, 13),
                    ShiftTypeId = 2,
                    TeamMemberId = 1,
                }
            };

            var shiftsDTO = new List<ShiftDTO>()
            {
                new ShiftDTO()
                {
                    ShiftDate = new DateTime(2023, 8, 12),
                    TeamMemberId = 1,
                    ShiftTypeName = "D",
                    ShiftTypeDescription = "Day-time shift",
                },
                new ShiftDTO()
                {
                    ShiftDate = new DateTime(2023, 8, 13),
                    TeamMemberId = 1,
                    ShiftTypeName = "N",
                    ShiftTypeDescription = "Night-time shift",
                }
            };
            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetAllShifts()).Returns(shiftsDTO.AsQueryable());
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);
            var actionResult = controller.GetShifts() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(shiftsDTO, actionResult.Value);
        }

        [Fact]
        public void GetShiftDTO_ValidId_ReturnsObject()
        {
            var shift = new Shift()
            {
                Id = 1,
                Date = new DateTime(2023, 8, 12),
                ShiftTypeId = 1,
                TeamMemberId = 1,
            };

            var shiftDTO = new ShiftDTO()
            {
                ShiftDate = new DateTime(2023, 8, 12),
                TeamMemberId = 1,
                ShiftTypeName = "D",
                ShiftTypeDescription = "Day-time shift",
            };
                
            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShift(1)).Returns(shiftDTO);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);
            var actionResult = controller.GetShift(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(shiftDTO, actionResult.Value);
        }
        [Fact]
        public void GetShiftDTO_InvalidId_ReturnsNotFound()
        {
            var shift = new Shift()
            {
                Id = 1,
                Date = new DateTime(2023, 8, 12),
                ShiftTypeId = 1,
                TeamMemberId = 1,
            };

            var shiftDTO = new ShiftDTO()
            {
                ShiftDate = new DateTime(2023, 8, 12),
                TeamMemberId = 1,
                ShiftTypeName = "D",
                ShiftTypeDescription = "Day-time shift",
            };

            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShift(1)).Returns(shiftDTO);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);
            var actionResult = controller.GetShift(123) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostShift_ValidRequest_SetsLocationHeader()
        {
            Shift shift = new() { Id = 1, Date = new DateTime(2023, 8, 12), ShiftTypeId = 1, TeamMemberId = 1 };

            var mockRepository = new Mock<IShiftRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.PostShift(shift) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetShift", actionResult.ActionName);
            Assert.Equal(shift.Id, actionResult.RouteValues["id"]);
            Assert.Equal(shift, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostShift_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.AddShift(It.IsAny<Shift>()))
                .Throws(new DataConflictException("A shift with the same ID already exists."));

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.PostShift(new Shift()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutShift_ValidRequest_ReturnsObject()
        {
            Shift shift = new() { Id = 1, Date = new DateTime(2023, 8, 12), ShiftTypeId = 1, TeamMemberId = 1 };

            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShiftById(1)).Returns(shift);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.PutShift(1, shift) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(shift, actionResult.Value);
        }

        [Fact]
        public void PutShift_ValidRequest_ReturnsUpdatedObject()
        {
            Shift initialShift = new() { Id = 1, Date = new DateTime(2023, 8, 12), ShiftTypeId = 1, TeamMemberId = 1 };
            Shift updatedShift = new() { Id = 1, Date = new DateTime(2023, 8, 11), ShiftTypeId = 1, TeamMemberId = 1 };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShiftById(1)).Returns(initialShift);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.PutShift(1, updatedShift);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as Shift;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedShift.Date, updatedObject.Date);
        }

        [Fact]
        public void DeleteShift_ValidId_ReturnsNoContent()
        {
            Shift shift = new() { Id = 1, Date = new DateTime(2023, 8, 12), ShiftTypeId = 1, TeamMemberId = 1 };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShiftById(1)).Returns(shift);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteShift(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeleteShift_InvalidId_ReturnsNotFound()
        {
            Shift shift = new() { Id = 1, Date = new DateTime(2023, 8, 12), ShiftTypeId = 1, TeamMemberId = 1 };

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new ShiftProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var mockRepository = new Mock<IShiftRepository>();
            mockRepository.Setup(x => x.GetShiftById(1)).Returns(shift);

            var controller = new ShiftsController(mockRepository.Object, mapper);

            var actionResult = controller.DeleteShift(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
