using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class GetSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<GetSaleCommand> getSaleHandlerFaker = new Faker<GetSaleCommand>()
        .RuleFor(s => s.Id, Guid.NewGuid());

    /// <summary>
    /// Configures the Faker to generate fake Sale data.
    /// </summary>
    private static readonly Faker<Sale> saleHandlerFaker = new Faker<Sale>()
        .RuleFor(s => s.Customer, f => new Faker<Customer>().Generate())
        .RuleFor(s => s.Items, f => f.Make(1, () => new SaleItem
        {
            Product = new Faker<Product>().Generate(),
            Quantity = f.Random.Number(1, 20)
        }));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static GetSaleCommand GenerateValidCommand()
    {
        return getSaleHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a fake Sale entity with randomized data.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateSaleData()
    {
        return saleHandlerFaker.Generate();
    }
}
