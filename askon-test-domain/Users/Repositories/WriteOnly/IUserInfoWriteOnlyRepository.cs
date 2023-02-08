namespace askon_test_domain.Users.Repositories.WriteOnly;

/// <summary>
/// Репозиторий для записи информации о пользователе
/// </summary>
public interface IUserInfoWriteOnlyRepository
{
	/// <summary>
	/// Сохранить
	/// </summary>
	/// <param name="userInfo"> Информация о пользователе </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Информация о пользователе </returns>
	Task<int> SaveAsync(UserInfo userInfo, CancellationToken token);
}