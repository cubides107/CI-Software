using CreditApp.Application.ProductServices.GetProduct;

namespace CreditApp.Application.ShoppingCarServices.GetShoppingCar;

public class GetShoppingCarDTO 
{
    public List<GetProductDTO> Products { get; set; }
    public double TotalPrice { get; set; }
}