using Microsoft.AspNetCore.Mvc;
using Moq;
using Raspored.Controllers;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RasporedTest.Controllers
{
    public class PositionsControllerTest
    {
        [Fact]
        public void GetPositions_ReturnsCollection()
        {
            List<Position> positions = new List<Position>()
            {
                new Position()
                {
                    Id = 1,
                    Name = "Foo"
                },
                new Position()
                {
                    Id = 2,
                    Name = "Bar"
                },
                new Position()
                {
                    Id = 3,
                    Name = "Foobar"
                }
            };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetAllPositions()).Returns(positions.AsQueryable());

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.GetPositions() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void GetPosition_ValidId_ReturnsObject()
        {
            Position position = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetPosition(1)).Returns(position);

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.GetPosition(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(position, actionResult.Value);
        }

        [Fact]
        public void GetPosition_InvalidId_ReturnsNotFound()
        {
            var mockRepository = new Mock<IPositionRepository>();

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.GetPosition(1) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostPosition_ValidRequest_SetsLocationHeader()
        {
            Position position = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IPositionRepository>();

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.PostPosition(position) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetPosition", actionResult.ActionName);
            Assert.Equal(position.Id, actionResult.RouteValues["id"]);
            Assert.Equal(position, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostPosition_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.AddPosition(It.IsAny<Position>()))
                .Throws(new DataConflictException("A position with the same ID already exists."));

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.PostPosition(new Position()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutPosition_ValidRequest_ReturnsObject()
        {
            Position position = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetPosition(1)).Returns(position);

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.PutPosition(1, position) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(position, actionResult.Value);
        }

        [Fact]
        public void PutPosition_ValidRequest_ReturnsUpdatedObject()
        {
            Position initialPosition = new() { Id = 1, Name = "Initial Name" };
            Position updatedPosition = new() { Id = 1, Name = "Updated Name" };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetPosition(1)).Returns(initialPosition);

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.PutPosition(1, updatedPosition);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as Position;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedPosition.Name, updatedObject.Name);
        }

        [Fact]
        public void DeletePosition_ValidId_ReturnsNoContent()
        {
            Position position = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetPosition(1)).Returns(position);

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.DeletePosition(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeletePosition_InvalidId_ReturnsNotFound()
        {
            Position position = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IPositionRepository>();
            mockRepository.Setup(x => x.GetPosition(1)).Returns(position);

            var controller = new PositionsController(mockRepository.Object);

            var actionResult = controller.DeletePosition(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
