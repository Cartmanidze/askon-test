using askon_test_application.Users.Responses;
using askon_test_domain.Exceptions;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace askon_test_application.Users.Requests;

/// <inheritdoc />
public record LoginRequest : IRequest<LoginResponse>
{
	/// <summary>
	/// Логин
	/// </summary>
	public string Login { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}

/// <inheritdoc />
public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
	private readonly IJwtGenerator _jwtGenerator;

	private readonly ILogger<LoginRequestHandler> _logger;

	private readonly SignInManager<User> _signInManager;

	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	private readonly UserManager<User> _userManager;

	/// <summary>
	/// .ctor
	/// </summary>
	public LoginRequestHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator,
								IUserInfoReadOnlyRepository userInfoReadOnlyRepository, ILogger<LoginRequestHandler> logger)
	{
		_logger = logger;
		_userManager = userManager;
		_signInManager = signInManager;
		_jwtGenerator = jwtGenerator;
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
	}

	/// <inheritdoc />
	public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
	{
		_logger.LogInformation("LoginRequest started");

		var user = await _userManager.FindByNameAsync(request.Login);

		if (user == null)
		{
			throw new UserNotFoundException(request.Login);
		}

		var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

		if (!result.Succeeded)
		{
			throw new();
		}

		var token = _jwtGenerator.CreateToken(user);

		var userInfo = await _userInfoReadOnlyRepository.GetAsync(user.Id, cancellationToken);

		return new()
		{
			Token = token,
			NickName = userInfo.NickName
		};
	}
}