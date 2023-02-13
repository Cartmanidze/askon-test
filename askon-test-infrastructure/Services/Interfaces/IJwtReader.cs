using Microsoft.AspNetCore.Http;

namespace askon_test_infrastructure.Services.Interfaces;

/// <summary>
/// JWT читатель
/// </summary>
public interface IJwtReader
{
	/// <summary>
	/// Получить имя пользователя
	/// </summary>
	/// <param name="userName"> Имя пользователя </param>
	/// <param name="httpContext"> Http контекст </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Имя пользователя </returns>
	string GetUserAsync(string userName, HttpContext httpContext, CancellationToken token);
}