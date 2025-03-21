using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
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
/// Contains unit tests for the <see cref="GetSaleHandler"/> class.
/// </summary>
public class GetSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSaleHandler> _logger;
    private readonly GetSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public GetSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<ILogger<GetSaleHandler>>();
        _handler = new GetSaleHandler(_saleRepository, _mapper, _logger);
    }

    /// <summary>
    /// Tests that a valid sale get request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid get request When getting sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        //Given
        var command = GetSaleHandlerTestData.GenerateValidCommand();
        var sale = GetSaleHandlerTestData.GenerateSaleData();
        var result = new GetSaleResult
        {
            Id = sale.Id,
            Number = sale.Number,
            Customer = sale.Customer,
            Items = sale.Items!.Select(item => new GetSaleResult.SaleItem
            {
                Product = item.Product,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            })
        };

        _mapper.Map<GetSaleResult>(sale).Returns(result);

        _saleRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(sale);

        //When
        var getSaleResult = await _handler.Handle(command, CancellationToken.None);

        //Then
        getSaleResult.Should().NotBeNull();
        getSaleResult.Id.Should().Be(sale.Id);
        getSaleResult.Should().BeEquivalentTo(result);
        
        await _saleRepository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }
}
