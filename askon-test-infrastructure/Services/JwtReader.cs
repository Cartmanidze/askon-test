using System.IdentityModel.Tokens.Jwt;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace askon_test_infrastructure.Services;

/// <inheritdoc />
public class JwtReader : IJwtReader
{
	/// <inheritdoc />
	public string GetNameIdClaimAsync(HttpContext httpContext)
	{
		var accessToken = httpContext.Request.Headers["Authorization"]
			.ToString()
			.Replace("Bearer ", "");

		var handler = new JwtSecurityTokenHandler();

		var jsonToken = handler.ReadToken(accessToken);

		var tokenS = jsonToken as JwtSecurityToken;

		var nameId = tokenS!.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId)
			.Value;

		return nameId;
	}
}