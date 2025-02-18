using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    /// <summary>
    /// Gets the product's name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets the product's price.
    /// </summary>
    public decimal Price { get; set; }
}
