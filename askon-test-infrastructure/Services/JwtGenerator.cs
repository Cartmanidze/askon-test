using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using askon_test_domain.Users;
using askon_test_infrastructure.Options;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace askon_test_infrastructure.Services;

/// <inheritdoc />
public class JwtGenerator : IJwtGenerator
{
	private readonly SymmetricSecurityKey _key;

	/// <summary>
	/// .ctor
	/// </summary>
	public JwtGenerator(IOptions<AuthOptions> authOptions) => _key = new(Encoding.UTF8.GetBytes(authOptions.Value.TokenKey));

	/// <inheritdoc />
	public string CreateToken(User user)
	{
		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.NameId, user.UserName)
		};

		var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new(claims),
			Expires = DateTime.Now.AddDays(7),
			SigningCredentials = credentials
		};

		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}