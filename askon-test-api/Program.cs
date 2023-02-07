using askon_test_dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDalServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();