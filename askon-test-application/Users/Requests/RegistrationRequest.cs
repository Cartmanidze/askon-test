using askon_test_application.Users.Responses;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace askon_test_application.Users.Requests;

/// <summary>
/// Запрос на регистрацию
/// </summary>
public record RegistrationRequest : IRequest<RegistrationResponse>
{
	/// <summary>
	/// Логин
	/// </summary>
	public string Login { get; set; } = null!;

	/// <summary>
	/// Ник
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}

/// <inheritdoc />
public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
{
	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	private readonly UserManager<User> _userManager;

	private readonly IUsersReadOnlyRepository _usersReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public RegistrationRequestHandler(IUsersReadOnlyRepository usersReadOnlyRepository, UserManager<User> userManager,
									IUserInfoReadOnlyRepository userInfoReadOnlyRepository)
	{
		_usersReadOnlyRepository = usersReadOnlyRepository;
		_userManager = userManager;
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
	}

	/// <inheritdoc />
	public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
	{
		var oldUser = await _usersReadOnlyRepository.GetAsync(request.Login, cancellationToken);

		if (oldUser != null)
		{
			throw new($"Пользователь с логином = {request.Login} уже существует");
		}

		var oldUserInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		if (oldUserInfo != null)
		{
			throw new($"Пользователь с ником = {request.NickName} уже существует");
		}

		var newUser = new User
		{
			UserName = request.Login,
			UserInfo = new()
			{
				NickName = request.NickName
			}
		};

		var result = await _userManager.CreateAsync(newUser, request.Password);

		if (result.Succeeded)
		{
			return new()
			{
				Succeeded = true
			};
		}

		var errors = string.Join(',', result.Errors.Select(x => x.Code));

		throw new($"Не удалось зарегистрировать пользователя. {errors}");
	}
}