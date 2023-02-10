using askon_test_domain.Templates;

namespace askon_test_domain.Users;

/// <summary>
/// Информация о пользователе
/// </summary>
public class UserInfo
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Описание профиля
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Путь к изображению профиля
	/// </summary>
	public string? Avatar { get; set; }

	/// <summary>
	/// Псевдоним
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Дата рождения
	/// </summary>
	public DateTime? BirthDate { get; set; }

	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	public Guid UserId { get; set; }

	/// <summary>
	/// Пользователь
	/// </summary>
	public User? User { get; set; }

	/// <summary>
	/// Шаблон
	/// </summary>
	public Template? Template { get; set; }
}