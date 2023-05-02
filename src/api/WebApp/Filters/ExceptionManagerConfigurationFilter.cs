using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filters
{
	public class ExceptionManagerConfigurationFilter : IExceptionFilter
	{
		private readonly IWebHostEnvironment webHostEnvironment;

		public ExceptionManagerConfigurationFilter(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}

		public void OnException(ExceptionContext context)
		{
			if (context.Exception is not null)
			{
				context.Result = new JsonResult(new ExceptionDTO
				{
					Message = context.Exception.Message,
					Type = context.Exception.GetType().ToString(),
					Aplication = this.webHostEnvironment.ApplicationName,
					StatusCode = StatusCodes.Status500InternalServerError
				});
			}
		}
	}
}
