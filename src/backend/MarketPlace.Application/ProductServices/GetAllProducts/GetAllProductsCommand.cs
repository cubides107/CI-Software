using CreditApp.Application.ProductServices.GetProduct;
using MarketPlace.Domain.ProductEntities;
using MediatR;

namespace CreditApp.Application.ProductServices.GetAllProducts;

public class GetAllProductsCommand : IRequest<List<GetProductDTO>>
{
}