namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Request model for getting a sale by ID
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleRequest
    /// </summary>
    /// <param name="id">Sale id to retrieve</param>
    public GetSaleRequest(Guid id)
    {
        Id = id;
    }
}
