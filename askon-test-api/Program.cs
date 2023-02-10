using System.Text;
using askon_test_api.Middleware;
using askon_test_api.Views;
using askon_test_application;
using askon_test_application.Profiles.Requests;
using askon_test_application.Templates.Requests;
using askon_test_application.Users.Requests;
using askon_test_dal;
using askon_test_infrastructure;
using askon_test_infrastructure.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.Debug()
	.CreateLogger();

builder.Host.UseSerilog();

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

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI();

app.UseApplyMigration();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapPost("/login", [AllowAnonymous](LoginView view, IMediator mediator, CancellationToken token) => mediator.Send(new LoginRequest
{
	Login = view.Login,
	Password = view.Password
}, token));

app.MapPost("/register",
	[AllowAnonymous](RegistrationView view, IMediator mediator, CancellationToken token) => mediator.Send(new RegistrationRequest
	{
		Login = view.Login,
		NickName = view.NickName,
		Password = view.Password
	}, token));

app.MapGet("/user/{nickName}", (string nickName, IMediator mediator, CancellationToken token) => mediator.Send(new GetProfileRequest
{
	NickName = nickName
}, token));

app.MapPut("/user/{nickName}", (string nickName, EditProfileView view, IMediator mediator, CancellationToken token) => mediator.Send(
	new EditProfileRequest
	{
		NickName = nickName,
		Email = view.Email,
		PhoneNumber = view.PhoneNumber,
		Avatar = view.Avatar,
		Description = view.Description,
		FirstName = view.FirstName,
		LastName = view.LastName,
		MiddleName = view.MiddleName
	}, token));

app.MapPut("/user/{nickName}/template", (string nickName, EditTemplateView view, IMediator mediator, CancellationToken token) =>
	mediator.Send(new EditTemplateRequest
	{
		NickName = nickName,
		Html = view.Html
	}, token));

app.Run();