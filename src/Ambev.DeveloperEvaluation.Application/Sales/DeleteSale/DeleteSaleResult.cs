namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Response model for DeleteSale operation
/// </summary>
public class DeleteSaleResult
{
    /// <summary>
    /// Indicates whether the deletion was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleResult
    /// </summary>
    /// <param name="success">The success result</param>
    public DeleteSaleResult(bool success)
    {
        Success = success;
    }
}
