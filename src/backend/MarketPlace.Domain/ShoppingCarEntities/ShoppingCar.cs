namespace MarketPlace.Domain.ShoppingCarEntities;

public class ShoppingCar : Entity
{
    public int UserId { get; set; }
    
    private ShoppingCar() : base() {}

    public ShoppingCar(int userId)
    {
        UserId = userId;
    }
}