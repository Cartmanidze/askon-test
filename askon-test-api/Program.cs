using System.Text;
using askon_test_api.Middleware;
using askon_test_api.Views;
using askon_test_application;
using askon_test_application.Profiles.Requests;
using askon_test_application.Templates.Requests;
using askon_test_application.Users.Requests;
using askon_test_application.Users.Services.Interfaces;
using askon_test_dal;
using askon_test_infrastructure;
using askon_test_infrastructure.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

var tokenAccess = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(nameof(AuthOptions))
	.Get<AuthOptions>()
	.TokenKey));

builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	})
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

builder.Services.AddAuthorization();

builder.Services.AddDalServices(builder.Configuration);

builder.Services.AddApplicationLayerServices();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapPost("/api/login", [AllowAnonymous](LoginView view, IMediator mediator, CancellationToken token) => mediator.Send(new LoginRequest
{
	Login = view.Login,
	Password = view.Password
}, token));

app.MapPost("/api/register",
	[AllowAnonymous](RegistrationView view, IMediator mediator, CancellationToken token) => mediator.Send(new RegistrationRequest
	{
		Login = view.Login,
		NickName = view.NickName,
		Password = view.Password
	}, token));

app.MapGet("/api/user/{nickName}",
	[Authorize(AuthenticationSchemes = "Bearer")]
	(string nickName, IMediator mediator, CancellationToken token) => mediator.Send(new GetProfileRequest
	{
		NickName = nickName
	}, token));

app.MapPut("/api/user/{nickName}",
	[Authorize(AuthenticationSchemes = "Bearer")]
	async (string nickName, EditProfileView view, IMediator mediator, IEnemyChecker enemyChecker, HttpContext context,
			CancellationToken token) =>
	{
		await enemyChecker.ThrowIfEnemyAsync(nickName, context, token);

		return await mediator.Send(new EditProfileRequest
		{
			NickName = nickName,
			Email = view.Email,
			PhoneNumber = view.PhoneNumber,
			Avatar = view.Avatar,
			Description = view.Description,
			FirstName = view.FirstName,
			LastName = view.LastName,
			MiddleName = view.MiddleName
		}, token);
	});

app.MapPut("/api/user/{nickName}/template",
	[Authorize(AuthenticationSchemes = "Bearer")]
	async (string nickName, EditTemplateView view, IMediator mediator, IEnemyChecker enemyChecker, HttpContext context,
			CancellationToken token) =>
	{
		await enemyChecker.ThrowIfEnemyAsync(nickName, context, token);

		return await mediator.Send(new EditTemplateRequest
		{
			NickName = nickName,
			Html = view.Html
		}, token);
	});

app.MapGet("/api/user/{nickName}/pdf",
	[Authorize(AuthenticationSchemes = "Bearer")]
	async (string nickName, IMediator mediator, IEnemyChecker enemyChecker, HttpContext context, CancellationToken token) =>
	{
		await enemyChecker.ThrowIfEnemyAsync(nickName, context, token);

		var (fileName, stream) = await mediator.Send(new GetPdfTemplateRequest(nickName), token);

		try
		{
			stream.Position = 0;

			return Results.File(stream, "application/pdf", fileName);
		}
		catch
		{
			await stream.DisposeAsync();

			throw;
		}
	});

app.MapGet("/api/user/{nickName}/doc",
	[Authorize(AuthenticationSchemes = "Bearer")]
	async (string nickName, IMediator mediator, IEnemyChecker enemyChecker, HttpContext context, CancellationToken token) =>
	{
		await enemyChecker.ThrowIfEnemyAsync(nickName, context, token);

		var (fileName, stream) = await mediator.Send(new GetDocTemplateRequest(nickName), token);

		try
		{
			stream.Position = 0;

			return Results.File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
		}
		catch
		{
			await stream.DisposeAsync();

			throw;
		}
	});

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.UseApplyMigration();

app.Run();