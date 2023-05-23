using System.Security.Claims;
using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarCommand : IRequest<int>, IRequest<List<GetProductDTO>>
{
    public List<Claim> UserClaims { get; set; }
    public List<int> ProducId { get; set; }
}