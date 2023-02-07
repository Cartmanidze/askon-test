namespace askon_test_infrastructure.Options;

/// <summary>
/// Настройки для авторизации/аутентификации
/// </summary>
public class AuthOptions
{
	/// <summary>
	/// Ключ для токена доступа
	/// </summary>
	public string TokenKey { get; set; } = null!;
}