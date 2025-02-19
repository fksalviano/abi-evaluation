using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer Id: Must not be empty    
    /// - Sale items: Must not be empty
    /// - Sale items: Product Id must not be empty
    /// - Sale items: Product Quantity must not be empty
    /// </remarks>
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage("Customer Id must not be empty");

        RuleFor(sale => sale.Items)
            .NotEmpty()
            .WithMessage("Sale items must not be empty");

        RuleFor(sale => sale)
            .Must(sale => sale.Items is not null && sale.Items.All(item => item.ProductId != default))
            .WithMessage("Product Id must not be empty")
            .Must(sale => sale.Items is not null && sale.Items.All(item => item.Quantity != default))
            .WithMessage("Product Quantity must not be empty");
    }    
}
