using Microsoft.AspNetCore.Http;

namespace askon_test_application.Users.Services.Interfaces;

/// <summary>
/// Не даёт пренебречь правами
/// </summary>
public interface IEnemyChecker
{
	/// <summary>
	/// Не враг ли это
	/// </summary>
	/// <param name="nickName"> Ник </param>
	/// <param name="httpContext"> Контекст </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Убить, если враг </returns>
	Task ThrowIfEnemyAsync(string nickName, HttpContext httpContext, CancellationToken token);
}