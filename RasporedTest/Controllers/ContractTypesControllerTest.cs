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
    public class ContractTypesControllerTest
    {
        [Fact]
        public void GetContractTypes_ReturnsCollection()
        {
            List<ContractType> contractTypes = new List<ContractType>()
            {
                new ContractType()
                {
                    Id = 1,
                    Name = "Foo"
                },
                new ContractType()
                {
                    Id = 2,
                    Name = "Bar"
                },
                new ContractType()
                {
                    Id = 3,
                    Name = "Foobar"
                }
            };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetAllContractTypes()).Returns(contractTypes.AsQueryable());

            var controller = new ContractTypesController(mockRepository.Object);
            var actionResult = controller.GetContractTypes() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void GetContractType_ValidId_ReturnsObject()
        {
            ContractType contractType = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetContractType(1)).Returns(contractType);

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.GetContractType(1) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(contractType, actionResult.Value);
        }

        [Fact]
        public void GetContractType_InvalidId_ReturnsNotFound()
        {
            var mockRepository = new Mock<IContractTypeRepository>();

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.GetContractType(1) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }

        [Fact]
        public void PostContractType_ValidRequest_SetsLocationHeader()
        {
            ContractType contractType = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IContractTypeRepository>();

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.PostContractType(contractType) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);
            Assert.Equal("GetContractType", actionResult.ActionName);
            Assert.Equal(contractType.Id, actionResult.RouteValues["id"]);
            Assert.Equal(contractType, actionResult.Value);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public void PostContractType_ValidRequest_ReturnsConflict()
        {
            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.AddContractType(It.IsAny<ContractType>()))
                .Throws(new DataConflictException("Contract type with the same ID already exists."));

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.PostContractType(new ContractType()) as ConflictObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(409, actionResult.StatusCode);
            Assert.NotNull(actionResult.Value);
        }

        [Fact]
        public void PutContractType_ValidRequest_ReturnsObject()
        {
            ContractType contractType = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetContractType(1)).Returns(contractType);

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.PutContractType(1, contractType) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);
            Assert.Equal(contractType, actionResult.Value);
        }

        [Fact]
        public void PutContractType_ValidRequest_ReturnsUpdatedObject()
        {
            ContractType initialContractType = new() { Id = 1, Name = "Initial Name" };
            ContractType updatedContractType = new() { Id = 1, Name = "Updated Name" };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetContractType(1)).Returns(initialContractType);

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.PutContractType(1, updatedContractType);

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var okResult = actionResult as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);

            var updatedObject = okResult.Value as ContractType;
            Assert.NotNull(updatedObject);
            Assert.Equal(updatedContractType.Name, updatedObject.Name);
        }

        [Fact]
        public void DeleteContractType_ValidId_ReturnsNoContent()
        {
            ContractType contractType = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetContractType(1)).Returns(contractType);

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.DeleteContractType(1) as NoContentResult;

            Assert.NotNull(actionResult);
            Assert.Equal(204, actionResult.StatusCode);
        }

        [Fact]
        public void DeleteContractType_InvalidId_ReturnsNotFound()
        {
            ContractType contractType = new() { Id = 1, Name = "Foo" };

            var mockRepository = new Mock<IContractTypeRepository>();
            mockRepository.Setup(x => x.GetContractType(1)).Returns(contractType);

            var controller = new ContractTypesController(mockRepository.Object);

            var actionResult = controller.DeleteContractType(121) as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.Equal(404, actionResult.StatusCode);
        }
    }
}
