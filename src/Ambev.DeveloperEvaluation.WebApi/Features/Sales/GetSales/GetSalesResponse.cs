using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSalesResponse
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
}
