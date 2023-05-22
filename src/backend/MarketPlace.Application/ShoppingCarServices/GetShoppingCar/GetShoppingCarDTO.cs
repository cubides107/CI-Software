using MarketPlace.Domain.ProductEntities;

namespace CreditApp.Application.ShoppingCarServices.GetShoppingCar;

public class GetShoppingCarDTO 
{
    public int UserId { get; set; }
    public List<Product> Products { get; set; }
}