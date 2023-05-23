using CreditApp.Application.ShoppingCarServices.GetShoppingCar;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.ShoppingCarEntities;
using MarketPlace.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.ShoppingCarServices.AddProductCar;

public class AddProductCarHandler : IRequestHandler<AddProductCarCommand, int>
{

    private readonly IRepository Repository;
    private readonly ISecurity Security;

    public AddProductCarHandler(IRepository repository, ISecurity security)
    {
        Repository = repository;
        Security = security;
    }
    
    public async Task<int> Handle(AddProductCarCommand request, CancellationToken cancellationToken)
    {
        int userId = int.Parse(Security.GetClaim(request.UserClaims, claimType: ISecurity.USERID));
        int productId = request.ProducId;
        bool exist = Repository.Exists<Product>(product1 => product1.Id == productId);
        Product product = null;
        if (exist) product = await Repository.Get<Product>(product2 => product2.Id == productId);

        ShoppingCar shoppingCar = new ShoppingCar(userId);

        if (product != null) product.AddShoppingCar(shoppingCar);

        await Repository.Save(shoppingCar);
        await Repository.Commit();

        return 0;
    }
}