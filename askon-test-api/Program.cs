using askon_test_application;
using askon_test_application.Users.Requests;
using askon_test_dal;
using askon_test_infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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

builder.Services.AddDalServices(builder.Configuration);

builder.Services.AddApplicationLayerServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.MapPost("/login", (LoginRequest request, IMediator mediator, CancellationToken token) => mediator.Send(request, token));

app.Run();