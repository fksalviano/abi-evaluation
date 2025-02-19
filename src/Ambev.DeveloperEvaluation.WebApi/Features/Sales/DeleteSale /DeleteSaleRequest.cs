namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Represents a request to delete a sale.
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleRequest
    /// </summary>
    /// <param name="id">Sale id to delete</param>
    public DeleteSaleRequest(Guid id)
    {
        Id = id;
    }
}
