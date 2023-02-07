namespace askon_test_application.Users.Models;

/// <summary>
/// Профиль пользователя
/// </summary>
public class Profile
{
	/// <summary>
	/// Эл.почта
	/// </summary>
	public string? Email { get; set; }

	/// <summary>
	/// Телефонный номер
	/// </summary>
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string LastName { get; set; } = null!;

	/// <summary>
	/// Имя
	/// </summary>
	public string FirstName { get; set; } = null!;

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }

	/// <summary>
	/// Путь к изображению профиля
	/// </summary>
	public string? Avatar { get; set; }

	/// <summary>
	/// Псевдоним
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Описание профиля
	/// </summary>
	public string? Description { get; set; }
}