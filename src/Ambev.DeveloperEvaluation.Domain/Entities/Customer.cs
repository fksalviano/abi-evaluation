using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Customer : BaseEntity
{
    /// <summary>
    /// Gets the customer's name
    /// </summary>
    public string? Name { get; set; }
}
