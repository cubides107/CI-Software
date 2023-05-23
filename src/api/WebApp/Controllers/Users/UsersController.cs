using CreditApp.Application.UsersServices.GetUser;
using CreditApp.Application.UsersServices.LoginUser;
using CreditApp.Application.UsersServices.RegisterUser;
using CreditApp.Application.UsersServices.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.Filters;

namespace WebApp.Controllers.Users
{
	[Route("api/[controller]")]
	[TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
	//[TypeFilter(typeof(Security))]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IMediator mediator;

		public UsersController(IMediator mediator)
		{
			this.mediator = mediator;
		}


		[HttpPut]
		[Route("RegisterUser")]
		public async Task<IActionResult> Register(RequestCreateUser request)
		{
			var command = new RegisterUserCommand
			{
				Email = request.Email,
				Names = request.Names,
				LastNames = request.LastNames,
				Password = request.Password,
			};
			var dto = await mediator.Send(command);
			return Ok(dto);
		}

		[HttpPost]
		[Route("UpdateUser")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Pastor")]
		public async Task<IActionResult> UpdateUser(RequestUpdateUser request)
		{
			var command = new UpdateUserCommand
			{
				Claims = User.Claims.ToList(),
				Email = request.Email,
				Names = request.Names,
				LastNames = request.LastNames,
				Address = request.Address,
				LandLine = request.LandLine,
				Congregation = request.Congregation,
				PhoneNumber = request.PhoneNumber,
				DateInitCorp = request.DateInitCorp,
				DateInitMin = request.DateInitMin,
				DateOfBirth = request.DateOfBirth,
				District = request.District,
				DocumentId = request.DocumentId,
				EPS = request.EPS,
				Height = request.Height,
				Weight = request.Weight,
				WifeNames = request.WifeNames,
				WifeLastNames = request.WifeLastNames,
				WifePhone = request.WifePhone,
				Childrens = request.Childrens,
				Persons = request.Persons
			};

			var dto = await mediator.Send(command);

			return Ok(dto);
		}

		[HttpGet]
		[Route("GetUser")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Pastor")]
		public async Task<IActionResult> GetUser()
		{
			var command = new GetUserQuery
			{
				Claims = User.Claims.ToList(),
			};

			var dto = await mediator.Send(command);

			return Ok(dto);
		}

		[HttpPut]
		[Route("LoginUser")]
		public async Task<IActionResult> LoginUser(LoginRequest request)
		{
			var command = new LoginUserCommand
			{
				Email = request.Email,
				Password = request.Password,
			};

			var dto = await mediator.Send(command);

			return Ok(dto);
		}
	}
}
