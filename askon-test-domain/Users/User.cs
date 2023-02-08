using Microsoft.AspNetCore.Identity;

namespace askon_test_domain.Users;

/// <summary>
/// Пользователь
/// </summary>
public class User : IdentityUser<Guid>
{
	/// <summary>
	/// Эл.почта
	/// </summary>
	public override string? Email { get; set; }

	/// <summary>
	/// Телефонный номер
	/// </summary>
	public override string? PhoneNumber { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string? LastName { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string? FirstName { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }

	/// <summary>
	/// Информация о пользователе
	/// </summary>
	public UserInfo? UserInfo { get; set; }
}