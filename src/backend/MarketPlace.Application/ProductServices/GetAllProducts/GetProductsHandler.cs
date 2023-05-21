using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.UsersServices.GetUser;
using MarketPlace.Domain;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.ProductServices.GetAllProducts;

public class GetProductsHandler : IRequestHandler<GetAllProductsCommand, List<GetProductDTO>>
{

    private readonly IRepository Repository;
    private readonly IMapObject MapObject;

    public GetProductsHandler(IRepository repository, IMapObject mapObject)
    {
        Repository = repository;
        MapObject = mapObject;
    }

    public async Task<List<GetProductDTO>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        List<Product> products = await Repository.GetAll<Product>();
        List<GetProductDTO> productDtos = new List<GetProductDTO>();
        foreach (Product product in products)
        {
            productDtos.Add(MapObject.Map<Product, GetProductDTO>(product));
        }
        return productDtos;
    }
}