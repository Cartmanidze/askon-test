using askon_test_application;
using askon_test_application.Users.Requests;
using askon_test_dal;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDalServices(builder.Configuration);

builder.Services.AddApplicationLayerServices();

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.MapPost("/login", (LoginRequest request, IMediator mediator, CancellationToken token) => mediator.Send(request, token));

app.Run();