namespace askon_test_api.Views;

/// <summary>
/// Представление для логина
/// </summary>
public class LoginView
{
	/// <summary>
	/// Эл.почта
	/// </summary>
	public string Email { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}