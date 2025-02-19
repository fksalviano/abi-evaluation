using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


/// <summary>
/// Command for creating a new sale.
/// </summary>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Sales's customer id.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Sales's items.
    /// Items with sales's products and quantities
    /// </summary>
    public IEnumerable<SaleItem>? Items { get; set; }


    /// <summary>
    /// Represents a sale item.
    /// </summary>
    public class SaleItem
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
