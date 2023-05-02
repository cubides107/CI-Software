using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filters
{
	public class Security
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{

		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			JsonResult jsonResult;
			IConfigurationBuilder builder = new ConfigurationBuilder();
			builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
			var root = builder.Build();
			string token = root.GetValue<string>("token");
			string clientToken = context.HttpContext.Request.Headers["token"];
			if (clientToken == null || clientToken != token)
			{
				jsonResult = new JsonResult(null)
				{
					StatusCode = 403,
					Value = "Error de Acceso, el token de acceso es incorrecto"
				};
				context.Result = jsonResult;

			}
		}
	}
}
