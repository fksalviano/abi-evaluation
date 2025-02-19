using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer Id: Must not be empty    
    /// - Sale items: Must not be empty
    /// - Sale items: Product Id must not be empty
    /// - Sale items: Product Quantity must not be empty
    /// </remarks>
    public CreateSaleRequestValidator()
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
