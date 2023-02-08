using askon_test_domain.Users;

namespace askon_test_domain.Templates;

/// <summary>
/// Шаблон
/// </summary>
public class Template
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Html шаблона
	/// </summary>
	public string? Html { get; set; }

	/// <summary>
	/// Идентификатор информации о пользователе
	/// </summary>
	public Guid UserInfoId { get; set; }

	/// <summary>
	/// Информация о пользователе
	/// </summary>
	public UserInfo? UserInfo { get; set; }
}