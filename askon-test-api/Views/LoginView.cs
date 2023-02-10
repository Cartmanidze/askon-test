namespace askon_test_api.Views;

/// <summary>
/// Представление для логина
/// </summary>
public class LoginView
{
	/// <summary>
	/// Логин
	/// </summary>
	public string Login { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}