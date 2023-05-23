using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.ShoppingCarEntities;
using MarketPlace.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarHandler : IRequestHandler<AddProductCarCommand, List<GetProductDTO>>
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
    
    public async Task<List<GetProductDTO>> Handle(AddProductCarCommand request, CancellationToken cancellationToken)
    {
        int userId = int.Parse(Security.GetClaim(request.UserClaims, claimType: ISecurity.USERID));
        List<int> productsId = request.ProducId;
        ShoppingCar shoppingCar = new ShoppingCar(userId);
        List<GetProductDTO> productDtos = new List<GetProductDTO>();
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
        
        await Repository.Save(shoppingCar);
        await Repository.Commit();

        return productDtos;
    }
}