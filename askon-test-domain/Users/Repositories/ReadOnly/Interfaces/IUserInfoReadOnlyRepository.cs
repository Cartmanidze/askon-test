namespace askon_test_domain.Users.Repositories.ReadOnly.Interfaces;

/// <summary>
/// Репозиторий для чтения информации о пользователе
/// </summary>
public interface IUserInfoReadOnlyRepository
{
	/// <summary>
	/// Получение информации о пользователе
	/// </summary>
	/// <param name="userId"> Идентификатор пользователя </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Информация о пользователе </returns>
	Task<UserInfo> GetAsync(Guid userId, CancellationToken token);

	/// <summary>
	/// Получение информации о пользователе
	/// </summary>
	/// <param name="ickName"> Ник пользователя </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Информация о пользователе </returns>
	Task<UserInfo> GetAsync(string nickName, CancellationToken token);
}