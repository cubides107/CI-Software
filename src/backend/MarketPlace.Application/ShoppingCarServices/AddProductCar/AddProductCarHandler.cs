using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.ShoppingCarEntities;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarHandler : IRequestHandler<AddProductCarCommand, GetShoppingCarDTO>
{

    private readonly IRepository Repository;
    private readonly IMapObject MapObject; 
    private readonly ISecurity Security;

    public AddProductCarHandler(IRepository repository, IMapObject mapObject, ISecurity security)
    {
        Repository = repository;
        MapObject = mapObject;
        Security = security;
    }
    
    public async Task<GetShoppingCarDTO> Handle(AddProductCarCommand request, CancellationToken cancellationToken)
    {
        int userId = int.Parse(Security.GetClaim(request.UserClaims, claimType: ISecurity.USERID));
        List<int> productsId = request.ProducId;
        ShoppingCar shoppingCar = new ShoppingCar(userId);
        List<GetProductDTO> productDtos = new List<GetProductDTO>();
        GetShoppingCarDTO shoppingCarFinal = new GetShoppingCarDTO();
        foreach (int productId in productsId)
        {
            bool exist = Repository.Exists<Product>(product1 => product1.Id == productId);
            Product product = null;
            if (exist)
            {
                product = await Repository.Get<Product>(product2 => product2.Id == productId);
                productDtos.Add(MapObject.Map<Product, GetProductDTO>(product));
            }
            
            if (product != null) product.AddShoppingCar(shoppingCar);
        }

        shoppingCarFinal.Products = productDtos;
        shoppingCarFinal.TotalPrice = CalculateTotalPrice(productDtos);
        
        await Repository.Save(shoppingCar);
        await Repository.Commit();

        return shoppingCarFinal;
    }

    private double CalculateTotalPrice(List<GetProductDTO> list)
    {
        double total = 0;
        foreach (GetProductDTO getProductDto in list)
        {
            total = total + getProductDto.Price;
        }

        return total;
    }
}