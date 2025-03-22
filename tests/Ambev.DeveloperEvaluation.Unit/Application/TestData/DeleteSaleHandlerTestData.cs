using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class DeleteSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static readonly Faker<DeleteSaleCommand> deleteSaleHandlerFaker = new Faker<DeleteSaleCommand>()
        .RuleFor(s => s.Id, Guid.NewGuid());

    /// <summary>
    /// Configures the Faker to generate fake Sale data.
    /// </summary>
    private static readonly Faker<Sale> saleHandlerFaker = new Faker<Sale>();

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static DeleteSaleCommand GenerateValidCommand()
    {
        return deleteSaleHandlerFaker.Generate();
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
