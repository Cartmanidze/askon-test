using askon_test_application.Users.Responses;
using askon_test_domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace askon_test_application.Users.Requests;

/// <inheritdoc />
public class LoginRequest : IRequest<LoginResponse>
{
	/// <summary>
	/// Эл.почта
	/// </summary>
	public string Email { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}

/// <inheritdoc />
public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
{
	private readonly SignInManager<User> _signInManager;

	private readonly UserManager<User> _userManager;

	/// <summary>
	/// .ctor
	/// </summary>
	public LoginRequestHandler(UserManager<User> userManager, SignInManager<User> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	/// <inheritdoc />
	public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
	{
		var user = await _userManager.FindByEmailAsync(request.Email);

		if (user == null)
		{
			throw new();
		}

		var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

		if (result.Succeeded)
		{
			return new()
			{
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				MiddleName = user.MiddleName,
				PhoneNumber = user.PhoneNumber,
				NickName = user.UserName
			};
		}

		throw new();
	}
}