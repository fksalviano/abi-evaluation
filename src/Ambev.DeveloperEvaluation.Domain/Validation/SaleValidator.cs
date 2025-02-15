using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage("Customer Id must not be empty");

        RuleFor(sale => sale.AmountTotal)
            .NotEmpty()
            .WithMessage("Amount Total must not be empty");

        RuleFor(sale => sale.Items)
            .NotEmpty()
            .WithMessage("Sale Items must contains item");

        RuleFor(sale => sale.Items)
            .Must(items => items is not null && 
                items.Select(item => item.Validate()).All(result => result.IsValid))
            .WithMessage("Sale Items must contains all items valid");
    }
}
