using System.Security.Claims;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace askon_test_infrastructure.Services;

/// <inheritdoc />
public class JwtReader : IJwtReader
{
	/// <inheritdoc />
	public string GetUserAsync(string nickName, HttpContext httpContext, CancellationToken token)
	{
		if (httpContext.User.Identity is not ClaimsIdentity identity)
		{
			throw new();
		}

		var claims = identity.Claims;

		var userName = claims.First(x => x.Type == JwtRegisteredClaimNames.NameId)
			.Value;

		return userName;
	}
}