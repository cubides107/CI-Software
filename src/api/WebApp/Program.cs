using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;
using MarketPlace.Infrastructure.Startup;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	x =>
	{
		x.SwaggerDoc("v1", new OpenApiInfo()
		{
			Title = "JWT",
			Version = "v1"
		});
		x.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
		{
			Name = "Authorization",
			Type = SecuritySchemeType.ApiKey,
			Scheme = "Bearer",
			BearerFormat = "JWT",
			In = ParameterLocation.Header,
			Description = "Token JWT"
		});
		x.AddSecurityRequirement(new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				new string[]{}
			}
		});
	});

CreditAppStartup.SetUp(builder.Services, builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	 options.TokenValidationParameters = new TokenValidationParameters
	 {
		 ValidateIssuer = true,
		 ValidateAudience = true,
		 ValidateLifetime = true,
		 ValidateIssuerSigningKey = true,
		 ValidIssuer = "myapp",
		 ValidAudience = "myapp",
		 IssuerSigningKey = new SymmetricSecurityKey(
		 Encoding.UTF8.GetBytes("sdfsdfsdfsdfsdfrerty456456")),
		 ClockSkew = TimeSpan.Zero
	 });

var app = builder.Build();


app.UseCors(policy =>
	policy
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
