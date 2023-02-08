using askon_test_domain.Users;

namespace askon_test_infrastructure.Services.Interfaces;

/// <summary>
/// Генератор JWT-токена
/// </summary>
public interface IJwtGenerator
{
	/// <summary>
	/// Создание токена доступа
	/// </summary>
	/// <param name="user"> Пользователь </param>
	/// <returns> Токен доступа </returns>
	string CreateToken(User user);
}