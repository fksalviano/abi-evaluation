using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetSaleCommand
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    
    /// <summary>
    /// Initializes validation rules for DeleteSaleCommand
    /// </summary>
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale Id is required");
    }    
}
