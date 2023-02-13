using askon_test_application.Users.Services.Interfaces;
using askon_test_domain.Exceptions;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace askon_test_application.Users.Services;

/// <inheritdoc />
public class EnemyChecker : IEnemyChecker
{
	private readonly IJwtReader _jwtReader;

	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public EnemyChecker(IUserInfoReadOnlyRepository userInfoReadOnlyRepository, IJwtReader jwtReader)
	{
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
		_jwtReader = jwtReader;
	}

	/// <inheritdoc />
	public async Task ThrowIfEnemyAsync(string nickName, HttpContext httpContext, CancellationToken token)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(nickName, token);

		var claimName = await _jwtReader.GetUserAsync(userInfo!.User!.UserName, httpContext, token);

		if (userInfo.User!.UserName!.Equals(claimName))
		{
			return;
		}

		throw new NoRightsException($"У пользователя с ником = {nickName} отсутствуют права");
	}
}