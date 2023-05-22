using MarketPlace.Domain.ProductEntities;

namespace MarketPlace.Domain.ShoppingCar;

public class ShoppingCar : Entity
{
    public int UserId { get; set; }
    public List<Product> Products { get; set; }
    
    private ShoppingCar() : base()
    {
        Products = new List<Product>();
    }

    public ShoppingCar(int userId)
    {
        UserId = userId;
    }
}