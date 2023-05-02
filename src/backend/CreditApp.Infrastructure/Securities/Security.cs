using CreditApp.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CreditApp.Infrastructure.Securities
{
	public class Security : ISecurity
	{
		public Security()
		{

		}

		public string CreateToken(string id, string name, string mail, string role)
		{
			//creamos el cleims
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, mail),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Name, name),
				new Claim("UserId", id),
				new Claim("mail", mail),
				new Claim("Userrole", role), //necesario para la verificaciones
                new Claim(ClaimTypes.Role, role) //necesario para las apis
			};

			//obtener variables de entorno
			string secret = "sdfsdfsdfsdfsdfrerty456456";
			string domain = "myapp";
			string dayString = "5";
			int dayExpires = int.Parse(dayString);

			//verificar variables de entorno
			if (secret == null || secret == "")
				throw new Exception("CLAVE SEGURIDAD nula");
			else if (domain == null || domain == "")
				throw new Exception("DOMINIO nulo");
			else if (dayString == null || dayString == "")
				throw new Exception("Token es nulo");

			//encriptar clave secreta,crear credenciales y dias de expiracion
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var issues = DateTime.UtcNow.AddDays(dayExpires); //expide

			//creamos el token con los datos anteriores
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: domain,
				audience: domain,
				claims: claims,
				expires: issues,//expide
				signingCredentials: credential
				);

			//retornamos el token tipo string
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public string EncryptPassword(string password)
		{
			//instancias variables
			SHA1 sha1 = SHA1.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream;
			StringBuilder sb = new StringBuilder();

			//encriptar
			stream = sha1.ComputeHash(encoding.GetBytes(password));
			for (int i = 0; i < stream.Length; i++)
			{
				sb.AppendFormat("{0:x2}", stream[i]);
			}

			return sb.ToString();
		}
		public string GetClaim(string token, string claimType)
		{
			//validar
			/*  ValidationsSecurity.Validator(token, ValidationsSecurity.checksToken);
              ValidationsSecurity.Validator(claimType, ValidationsSecurity.checksClaims);*/

			//crear token apartir del string
			var tokenHandler = new JwtSecurityTokenHandler();
			var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

			//obtener claim segun el parametro
			var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
			return stringClaimValue;
		}

		public string GetClaim(List<Claim> claims, string claimType)
		{
			/*ValidationsSecurity.Validator(claimType, ValidationsSecurity.checksClaims);*/

			var claim = claims.First(claim => claim.Type == claimType).Value;
			return claim;
		}
	}
}
