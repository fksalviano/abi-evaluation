using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSalesHandler : IRequestHandler<GetSalesCommand, IEnumerable<GetSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSalesHandler> _logger;


    /// <summary>
    /// Initializes a new instance of GetSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="logger">The Logger instance</param>
    public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSalesHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the GetSalesCommand request
    /// </summary>
    /// <param name="request">The GetSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale list if found</returns>    
    public async Task<IEnumerable<GetSalesResult>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting Sales: {request}", JsonSerializer.Serialize(request));

        var sales = await _saleRepository.GetAsync(cancellationToken);
        
        if (!sales.Any())
        {
            _logger.LogError("Sales not found");
            throw new KeyNotFoundException($"Sales not found");
        }

        var result = _mapper.Map<IEnumerable<GetSalesResult>>(sales);
        _logger.LogInformation("Sales result: {result}", JsonSerializer.Serialize(result));


        return result;        
    }
}
