using Microsoft.AspNetCore.Identity;

namespace askon_test_domain.Users;

/// <summary>
/// Пользователь
/// </summary>
public class User : IdentityUser
{
	/// <summary>
	/// Фамилия
	/// </summary>
	public string LastName { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string FirstName { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }
}