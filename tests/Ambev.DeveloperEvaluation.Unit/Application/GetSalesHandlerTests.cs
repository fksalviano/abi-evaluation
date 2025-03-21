using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="GetSalesHandler"/> class.
/// </summary>
public class GetSalesHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSalesHandler> _logger;
    private readonly GetSalesHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public GetSalesHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<ILogger<GetSalesHandler>>();
        _handler = new GetSalesHandler(_saleRepository, _mapper, _logger);
    }

    /// <summary>
    /// Tests that a valid sale get request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid get request When getting sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        //Given
        var command = GetSalesHandlerTestData.GenerateValidCommand();
        var sales = GetSalesHandlerTestData.GenerateSalesData();
        var result = sales.Select(sale => new GetSalesResult
        {
            Id = sale.Id,
            Number = sale.Number,
            Customer = sale.Customer
        });

        _mapper.Map<IEnumerable<GetSalesResult>>(sales).Returns(result);

        _saleRepository.GetAsync(Arg.Any<CancellationToken>()).Returns(sales);

        //When
        var getSalesResult = await _handler.Handle(command, CancellationToken.None);

        //Then
        getSalesResult.Should().NotBeNull();
        getSalesResult.Should().BeEquivalentTo(result);
        
        await _saleRepository.Received(1).GetAsync(Arg.Any<CancellationToken>());
    }
}
