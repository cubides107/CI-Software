using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers.Users
{
	public class RequestCreateUser
	{
		[MaxLength(30, ErrorMessage = "El nombre debe ser de maximo 30 caracteres")]
		public string Names { get; set; }

		[MaxLength(30, ErrorMessage = "Los apellidos deben ser de maximo 30 caracteres")]
		public string LastNames { get; set; }

		[EmailAddress(ErrorMessage = "Email Invalido")]
		public string Email { get; set; }

		public string Password { get; set; }

		/*	[MaxLength(20, ErrorMessage = "La ciudad debe ser de maximo 20 caracteres")]
			public string Country { get; set; }*/

		/*[MaxLength(20, ErrorMessage = "La EPS debe ser de maximo 20 caracteres")]
		public string EPS { get; set; }

		public double Height { get; set; }

		public double Weight { get; set; }

		public DateTime DateInitCorp { get; set; }

		public DateTime DateInitMinistry { get; set; }

		public string District { get; set; }*/

	}
}
