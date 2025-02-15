using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.SaleId)
            .NotEmpty()
            .WithMessage("Sale Id must not be empty");

        RuleFor(item => item.ProductId)
            .NotEmpty()
            .WithMessage("Product Id must not be empty");

        RuleFor(item => item.Quantity)
            .InclusiveBetween(1, 20)
            .WithMessage("Quantity should be at least 1 and maximum of 20");

        RuleFor(item => item.UnitPrice)
            .NotEmpty()
            .WithMessage("Unit Price must not be empty");

        RuleFor(item => item.AmountTotal)
            .NotEmpty()
            .WithMessage("Amount Total must not be empty");
    }
}
