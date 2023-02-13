using askon_test_domain.Users;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace askon_test_infrastructure.Services;

/// <inheritdoc />
public class JwtReader : IJwtReader
{
	private readonly UserManager<User> _userManager;

	/// <summary>
	/// .ctor
	/// </summary>
	public JwtReader(UserManager<User> userManager) => _userManager = userManager;

	/// <inheritdoc />
	public async Task<string> GetUserAsync(string userName, HttpContext httpContext, CancellationToken token)
	{
		var user = await _userManager.FindByNameAsync(userName);

		var userClaims = await _userManager.GetClaimsAsync(user);

		var userClaim = userClaims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId);

		return userClaim!.Value;
	}
}