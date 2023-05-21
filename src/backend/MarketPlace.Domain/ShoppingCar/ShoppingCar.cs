using MarketPlace.Domain.ProductEntities;

namespace MarketPlace.Domain.ShoppingCar;

public class ShoppingCar : Entity
{
    public int UserId { get; set; }
    public List<Product> Products { get; set; }
}