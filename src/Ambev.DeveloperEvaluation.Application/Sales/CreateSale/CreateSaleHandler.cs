using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="customerRepository">The customer repository</param>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, ICustomerRepository customerRepository, IProductRepository productRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;        
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="request">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>c</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = _mapper.Map<Sale>(request);

        var customer = await _customerRepository.GetByIdAsync(sale.CustomerId, cancellationToken);
        if (customer is null)
            throw new KeyNotFoundException($"Customer Id {sale.CustomerId} not found");

        foreach (var item in sale.Items!)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product is null)
                throw new KeyNotFoundException($"Product Id {item.ProductId} not found");

            item.UnitPrice = product.Price;
            item.CalculateTotal();
        }

        sale.CalculateTotal();
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}
