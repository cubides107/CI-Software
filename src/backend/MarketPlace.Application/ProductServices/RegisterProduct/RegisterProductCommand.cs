using System.Security.Claims;
using CreditApp.Application.ProductServices.GetProduct;
using MediatR;

namespace CreditApp.Application.ProductServices.RegisterProduct;

public class RegisterProductCommand : IRequest<GetProductDTO>
{
    public String Name { get; set; }
    public double Price { get; set; }
    public String Description { get; set; }
    public List<Claim> Claims { get; set; }

    public int Stock;
    public String Reference;
}