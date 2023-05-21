using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Domain.ProductEntities;

public class Product : Entity
{
    
    [MaxLength(30)]
    public String Name { get; set; }
    public double Price { get; set; }
    public String Description { get; set; }
    public int Stock { get; set; }
    public String Reference { get; set; }
    
    public Product() : base(){}

    public Product(String name, double price, String description, int stock, String reference)
    {
        Name = name;
        Price = price;
        Description = description;
        Stock = stock;
        Reference = reference;
    }
}