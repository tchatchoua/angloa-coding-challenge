using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.Domain.Dtos;
using AA.CommoditiesDashboard.Domain.Services;
using AA.CommoditiesDashboard.Tests.Data;
using FluentAssertions;
using Xunit;

namespace AA.CommoditiesDashboard.Tests.Services;

public class ModelServiceTests : BaseServiceTests
{
    private readonly IModelService _modelService;

    public ModelServiceTests()
    {
        var repository = new InMemoryRepository<Model>(UnitOfWork);

        _modelService = new ModelService(repository);

        repository.AddRange(Models.All);

        repository.SaveChanges();
    }

    [Fact]
    public async Task Given_GetAllAsync_When_FetchingModels_Then_ReturnAllModels()
    {
        // Arrange
        var expectedCount = 5;

        // Act
        var models = await _modelService.GetAllAsync(CancellationToken.None);

        // Assert
        Assert.Equal(expectedCount, models.Count());
    }

    [Fact]
    public async Task Given_GetByIdAsync_When_FetchingModel_Then_ReturnValidModel()
    {
        // Arrange
        var modelId = 5;
        var expectedModel = new ModelDto
        {
            Id = 5,
            Name = "Model5"
        };

        // Act

        var model = await _modelService.GetByIdAsync(modelId, CancellationToken.None);

        // Assert
        model.Should().BeEquivalentTo(expectedModel);
    }

    [Fact]
    public async Task Given_GetByIdAsyncWithInvalidId_When_FetchingModel_Then_ReturnNull()
    {
        // Arrange
        var modelId = 10;

        // Act

        var model = await _modelService.GetByIdAsync(modelId, CancellationToken.None);

        // Assert
        Assert.Null(model);
    }
}