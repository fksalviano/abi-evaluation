using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Rsponse model for GetSales operation
/// </summary>
public class GetSalesResult
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
