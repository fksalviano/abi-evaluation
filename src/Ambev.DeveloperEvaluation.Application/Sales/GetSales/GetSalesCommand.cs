using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Command for retrieving sales
/// </summary>
public class GetSalesCommand : IRequest<IEnumerable<GetSalesResult>>
{

}
