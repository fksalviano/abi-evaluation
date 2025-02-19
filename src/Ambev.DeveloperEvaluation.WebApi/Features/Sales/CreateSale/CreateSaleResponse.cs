using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateSale operation
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// Sales's id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sales's number.
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    /// Sales's customer.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Sales's total amount.
    /// </summary>
    public decimal AmountTotal { get; set; }

    /// <summary>
    /// Sales's items.
    /// Items with sales's products and quantities
    /// </summary>
    public IEnumerable<SaleResponseItem>? Items { get; set; }


    /// <summary>
    /// Represents a sale response item.
    /// </summary>
    public class SaleResponseItem
    {
        /// <summary>
        /// Sale item's product.
        public Product? Product { get; set; }

        /// <summary>
        /// Sale item's quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Sale item's unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Sale item's discounts.
        /// </summary>
        public decimal Discounts { get; set; }

        /// <summary>
        /// Sale item's total amount.
        /// </summary>
        public decimal AmountTotal { get; set; }
    }
}
