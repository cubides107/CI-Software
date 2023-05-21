using System.Security.Claims;
using MediatR;

namespace CreditApp.Application.ProductServices.GetProduct;

public class GetProductQuery : List<GetProductDTO>
{
    public List<Claim> Claims { get; set; }
}