using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSaleHandler> _logger;


    /// <summary>
    /// Initializes a new instance of GetSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="logger">The Logger instance</param>
    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the GetSaleCommand request
    /// </summary>
    /// <param name="request">The GetSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found</returns>    
    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting Sale: {request}", JsonSerializer.Serialize(request));

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (sale is null)
        {
            _logger.LogError("Sale Id {saleId} not found", request.Id);
            throw new KeyNotFoundException($"Sale Id {request.Id} not found");
        }

        var result = _mapper.Map<GetSaleResult>(sale);
        _logger.LogInformation("Sale result: {result}", JsonSerializer.Serialize(result));

        return result;
        
    }
}
