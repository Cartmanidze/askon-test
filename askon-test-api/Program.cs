using System.Text;
using askon_test_application;
using askon_test_application.Users.Requests;
using askon_test_dal;
using askon_test_infrastructure;
using askon_test_infrastructure.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option =>
{
	option.EnableEndpointRouting = false;

	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.RequireAuthenticatedUser()
		.Build();

	option.Filters.Add(new AuthorizeFilter(policy));
});

var tokenAccess = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(nameof(AuthOptions))
	.Get<AuthOptions>()
	.TokenKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(opt =>
	{
		opt.TokenValidationParameters = new()
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = tokenAccess,
			ValidateAudience = false,
			ValidateIssuer = false
		};
	});

builder.Services.AddDalServices(builder.Configuration);

builder.Services.AddApplicationLayerServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.UseApplyMigration();

app.MapPost("/login", [AllowAnonymous](LoginRequest request, IMediator mediator, CancellationToken token) => mediator.Send(request, token));

app.MapPost("/register",
	[AllowAnonymous](RegistrationRequest request, IMediator mediator, CancellationToken token) => mediator.Send(request, token));

app.Run();