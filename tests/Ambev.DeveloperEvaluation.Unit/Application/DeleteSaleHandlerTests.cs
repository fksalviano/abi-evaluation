using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="DeleteSaleHandler"/> class.
/// </summary>
public class DeleteSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<DeleteSaleHandler> _logger;
    private readonly DeleteSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public DeleteSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _logger = Substitute.For<ILogger<DeleteSaleHandler>>();
        _handler = new DeleteSaleHandler(_saleRepository, _logger);
    }

    /// <summary>
    /// Tests that a valid sale deletion request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid deletion request When deleting sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        //Given
        var command = DeleteSaleHandlerTestData.GenerateValidCommand();
        var sale = DeleteSaleHandlerTestData.GenerateSaleData();

        _saleRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(sale);

        //When
        var deletedSaleResult = await _handler.Handle(command, CancellationToken.None);

        //Then
        deletedSaleResult.Should().NotBeNull();
        deletedSaleResult.Success.Should().BeTrue();
        
        sale.Cancelled.Should().BeTrue();
        await _saleRepository.Received(1).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }
}
