using System.Security.Claims;
using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarCommand : IRequest<int>
{
    public List<Claim> UserClaims { get; set; }
    public int ProducId { get; set; }
}