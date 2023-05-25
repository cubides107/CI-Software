using CreditApp.Application.ShoppingCarServices.AddProductCar;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers.ShoppingCar
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
    [ApiController]
    public class ShoppingCarController : ControllerBase
    {
        private IMediator Mediator;

        public ShoppingCarController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPut]
        [Route("AddProductCar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> AddProductCar(AddProductRequest request)
        {
            var command = new AddProductCarCommand()
            {
                UserClaims = User.Claims.ToList(),
                ProducId = request.ProductId
            };

            var dto = await Mediator.Send(command);

            return Ok(dto);
        }
    }
}