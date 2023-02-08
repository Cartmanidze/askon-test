namespace askon_test_api.Views;

/// <summary>
/// Представление для регистрации
/// </summary>
public class RegistrationView
{
	/// <summary>
	/// Логин
	/// </summary>
	public string Login { get; set; } = null!;

	/// <summary>
	/// Ник
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	public string Password { get; set; } = null!;
}