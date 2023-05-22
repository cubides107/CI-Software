using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.ShoppingCar;
using MarketPlace.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarHandler : IRequestHandler<AddProductCarCommand, int>
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
    
    public async Task<int> Handle(AddProductCarCommand request, CancellationToken cancellationToken)
    {
        int userId = int.Parse(Security.GetClaim(request.UserClaims, claimType: ISecurity.USERID));
        int productId = request.ProducId;
        bool exist = Repository.Exists<Product>(product => product.Id == userId);
        Product product = null;
        if (exist)
        {
             product = await Repository.Get<Product>(product => product.Id == userId);
        }
        else
        {
        }

        ShoppingCar shoppingCar = new ShoppingCar(
            userId
        );

        if (product != null) shoppingCar.Products.Add(product);

        await Repository.Save(shoppingCar);
        await Repository.Commit();

        return 0;
    }
}