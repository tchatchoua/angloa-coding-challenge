using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Controllers;
using AA.CommoditiesDashboard.Domain.Dtos;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AA.CommoditiesDashboard.Tests.Controllers;

public class ModelsControllerTests
{
    private readonly ModelsController _controller;
    private readonly Mock<IModelService> _mockModelService = new();

    public ModelsControllerTests()
    {
        _controller = new ModelsController(_mockModelService.Object);
    }

    [Fact]
    public async Task Given_Get_When_FetchingModels_Then_ReturnOkStatusCode()
    {
        // Arrange
        _mockModelService.Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new List<ModelDto>());

        // Act
        var response = await _controller.Get(CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task Given_GetById_When_FetchingModel_Then_ReturnOkStatusResponse()
    {
        // Arrange
        _mockModelService.Setup(s => s.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new ModelDto());

        // Act
        var response = await _controller.Get(CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task Given_GetByIdWithInvalidId_When_FetchingModel_Then_ReturnNotFoundStatusResponse()
    {
        // Arrange
        var modelId = 1;
        _mockModelService.Setup(s => s.GetByIdAsync(It.Is<int>(id => id == modelId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => null);

        // Act
        var response = await _controller.GetById(modelId, CancellationToken.None);

        // Assert
        Assert.IsType<NotFoundResult>(response);
    }
}