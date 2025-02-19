using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Handler for processing GetSaleCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSalesCommand, IEnumerable<GetSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSalesCommand request
    /// </summary>
    /// <param name="request">The GetSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale list if found</returns>    
    public async Task<IEnumerable<GetSalesResult>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAsync(cancellationToken);
        
        if (!sales.Any())
            throw new KeyNotFoundException($"Sales not found");

        var result = _mapper.Map<IEnumerable<GetSalesResult>>(sales);
        return result;        
    }
}
