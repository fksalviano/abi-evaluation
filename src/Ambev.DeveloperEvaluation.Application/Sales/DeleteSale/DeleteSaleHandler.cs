using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<DeleteSaleHandler> _logger;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="logger">The Logger instance</param>
    public DeleteSaleHandler(ISaleRepository saleRepository, ILogger<DeleteSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _logger = logger;
    }

    /// <summary>
    /// Handles the DeleteSaleCommand request 
    /// Performs logical deletion by cancelling the sale
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The result of the delete operation</returns>    
    public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cancelling Sale: {request}", JsonSerializer.Serialize(request));

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (sale is null)
            throw new KeyNotFoundException($"Sale Id {request.Id} not found");

        sale.Cancel();
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        _logger.LogInformation("Sale cancelled: {sale}", JsonSerializer.Serialize(sale));
        return new DeleteSaleResult(true);
    }
}
