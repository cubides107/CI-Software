using System.Runtime.CompilerServices;
using CreditApp.Application.ProductServices.GetProduct;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.ProductServices.RegisterProduct;

public class RegisterProductHandler : IRequestHandler<RegisterProductCommand, GetProductDTO>
{

    private readonly IRepository repository;
    private readonly IMapObject mapObject;
    private readonly ISecurity security;

    public RegisterProductHandler(IRepository repository, IMapObject mapObject, ISecurity security)
    {
        this.repository = repository;
        this.mapObject = mapObject;
        this.security = security;
    }
    
    public async Task<GetProductDTO> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {

        User user;
        int userId = int.Parse(security.GetClaim(request.Claims, claimType: ISecurity.USERID));
        user = await repository.Get<User>(user1 => user1.Id == userId);
        
        Product product = new Product(
            name: request.Name, 
            price: request.Price,
            description: request.Description, 
            stock: request.Stock,
            reference: request.Reference);

        user.AddProduct(product);
        await repository.Save(product);
        await repository.Commit();
        
        return mapObject.Map<Product, GetProductDTO>(product);
    }
}