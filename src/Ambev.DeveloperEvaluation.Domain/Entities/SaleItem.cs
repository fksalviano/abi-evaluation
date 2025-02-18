using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale item.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the item sale id
    /// Refers to sale that item is part of
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the item sale
    /// Sale that item is part of
    /// </summary>
    public Sale? Sale { get; set; }

    /// <summary>
    /// Gets the item's product id.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the item's product.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Gets the item's quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the item's unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the item's discounts.
    /// </summary>
    public decimal Discounts { get; set; }

    /// <summary>
    /// Gets the item's total amount.
    /// </summary>
    public decimal AmountTotal { get; set; }

    /// <summary>
    /// Performs validation of the sale item entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Maximum 20 items per product</list>
    /// <list type="bullet">Quantity at least 1</list>
    /// <list type="bullet">Unit price not empty</list>
    /// <list type="bullet">Amount Total not empty</list>
    ///
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Calculates the items's total amount based on quantity and unit price.
    /// <listheader>It also calculates the item's discounts:</listheader>
    /// <list type="bullet">No discount for quantity below 4 items</list>
    /// <list type="bullet">10% discount for 4+ items</list>
    /// <list type="bullet">20% discount for 10-20 items</list>
    /// </summary>
    public void CalculateTotal()
    {
        AmountTotal = UnitPrice * Quantity;

        var percentDiscount = this switch
        {
            { Quantity: < 4 } => 0,
            { Quantity: >= 4  and < 10 } => 10,
            { Quantity: >= 10 and < 20 } => 20,
            _ => 0
        };
        
        if (percentDiscount == 0)
        {
            Discounts = 0;
            return;            
        }

        Discounts = (percentDiscount / 100) * AmountTotal;
        AmountTotal = AmountTotal - Discounts;
    }    
}
