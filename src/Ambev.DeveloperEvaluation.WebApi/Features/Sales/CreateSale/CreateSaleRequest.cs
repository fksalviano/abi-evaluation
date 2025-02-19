namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Sales's customer id.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Sales's items.
    /// Items with sales's products and quantities
    /// </summary>
    public IEnumerable<SaleRequestItem>? Items { get; set; }


    /// <summary>
    /// Represents a sale request item.
    /// </summary>
    public class SaleRequestItem
    {
        /// <summary>
        /// Sale item's product id.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Sale item's quantity.
        /// </summary>
        public int Quantity { get; set; }
    }   
}
