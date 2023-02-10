using askon_test_application.Users.Requests;
using FluentValidation;

namespace askon_test_application.Users.Validators;

/// <summary>
/// Валидатор для запроса на логин
/// </summary>
internal sealed class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
	/// <inheritdoc />
	public RegistrationRequestValidator()
	{
		RuleFor(x => x.Login)
			.NotEmpty();

		RuleFor(x => x.NickName)
			.NotEmpty();

		RuleFor(x => x.Password)
			.NotEmpty();
	}
}