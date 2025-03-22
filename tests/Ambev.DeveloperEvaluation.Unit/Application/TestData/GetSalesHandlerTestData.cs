using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class GetSalesHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<GetSalesCommand> getSalesHandlerFaker = new Faker<GetSalesCommand>();

    /// <summary>
    /// Configures the Faker to generate fake Sale data.
    /// </summary>
    private static readonly Faker<Sale> salesHandlerFaker = new Faker<Sale>()
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
    public static GetSalesCommand GenerateValidCommand()
    {
        return getSalesHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a fake Sale entity with randomized data.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static IEnumerable<Sale> GenerateSalesData()
    {
        return salesHandlerFaker.GenerateBetween(3, 5);
    }
}
