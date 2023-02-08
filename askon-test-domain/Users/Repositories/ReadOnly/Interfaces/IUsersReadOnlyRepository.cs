namespace askon_test_domain.Users.Repositories.ReadOnly.Interfaces;

/// <summary>
/// Репозиторий для чтения пользователей
/// </summary>
public interface IUsersReadOnlyRepository
{
	/// <summary>
	/// Получить пользователя по email и login
	/// </summary>
	/// <param name="login"> Логин </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Пользователь </returns>
	Task<User?> GetAsync(string login, CancellationToken token);
}