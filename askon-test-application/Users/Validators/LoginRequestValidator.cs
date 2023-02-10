using askon_test_application.Users.Requests;
using FluentValidation;

namespace askon_test_application.Users.Validators;

/// <summary>
/// Валидатор для запроса на логин
/// </summary>
internal sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
	/// <inheritdoc />
	public LoginRequestValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty();

		RuleFor(x => x.Password)
			.NotEmpty();
	}
}