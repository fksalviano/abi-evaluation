using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale with sale items.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sales's number.
    /// It's auto-generated when sale is created.
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    /// Gets the sales's customer id.
    /// Refers to customer for who sale was made
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the sales's customer.
    /// Customer for who sale was made
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Gets the sales's total amount.
    /// Total amount of all sale's items
    /// </summary>
    public decimal AmountTotal { get; set; }

    /// <summary>
    /// Gets the sales's items.
    /// Items with sales's products and values
    /// </summary>
    public IEnumerable<SaleItem>? Items { get; set; }

    /// <summary>
    /// Gets the sales's cancelled status.
    /// </summary>
    public bool Cancelled { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the sale's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Cancelled = false;
    }

    /// <summary>
    /// Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Items not empty and all items valid</list>
    /// <list type="bullet">Amount Total not empty</list>
    ///
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Calculates sale's total amount based on sale's items
    /// </summary>
    public void CalculateTotal()
    {
        if (Items is null)
        {
            AmountTotal = 0;
            return;
        }

        AmountTotal = Items.Sum(item => item.AmountTotal);
    }

    /// <summary>
    /// Cancel the sale.
    /// Sets the salse's status cancelled.
    /// </summary>
    public void Cancel()
    {
        Cancelled = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
