namespace askon_test_application.Users.Responses;

/// <inheritdoc />
public class LoginResponse
{
	/// <summary>
	/// Ник
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Токен доступа
	/// </summary>
	public string Token { get; set; } = null!;
}