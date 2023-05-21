namespace WebApp.Controllers.Product;

public class RegisterRequest
{
    public String Name { get; set; }
    public double Price { get; set; }   
    public String Description { get; set; }
    public int Stock { get; set; }
    public String Reference { get; set; }
}