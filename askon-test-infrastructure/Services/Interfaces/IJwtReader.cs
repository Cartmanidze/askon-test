using Microsoft.AspNetCore.Http;

namespace askon_test_infrastructure.Services.Interfaces;

/// <summary>
/// JWT читатель
/// </summary>
public interface IJwtReader
{
	/// <summary>
	/// Получить NameId claim
	/// </summary>
	/// <param name="httpContext"> Http контекст </param>
	/// <returns> NameId claim </returns>
	string GetNameIdClaimAsync(HttpContext httpContext);
}