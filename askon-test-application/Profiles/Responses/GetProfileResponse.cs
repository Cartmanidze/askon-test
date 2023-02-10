namespace askon_test_application.Profiles.Responses;

/// <summary>
/// Ответ на получение профиля
/// </summary>
public class GetProfileResponse
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

	/// <summary>
	/// Html шаблон
	/// </summary>
	public string? Html { get; set; }

	/// <summary>
	/// Дата рождения
	/// </summary>
	public DateTime? BirthDate { get; set; }
}