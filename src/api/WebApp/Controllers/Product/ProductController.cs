using System.Security.Claims;
using CreditApp.Application.ProductServices.GetAllProducts;
using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.ProductServices.RegisterProduct;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers.Product;

[Route("api/[controller]")]
[TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
//[TypeFilter(typeof(Security))]
[ApiController]
public class ProductController : ControllerBase
{
    private IMediator mediator;

    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPut]
    [Route("RegisterProduct")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public async Task<IActionResult> RegisterProduct(RegisterRequest request)
    {
        var command = new RegisterProductCommand
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            Stock = request.Stock,
            Reference = request.Reference,
            Claims = User.Claims.ToList()
        };

        var dto = await mediator.Send(command);

        return Ok(dto);
    }
    
    [HttpGet]
    [Route("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var command = new GetAllProductsCommand();
        {
            
        };

        var dto = await mediator.Send(command);

        return Ok(dto);
    }
}