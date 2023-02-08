using askon_test_application.Users.Requests;
using FluentValidation;

namespace askon_test_application.Users.Validators;

/// <inheritdoc />
public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
	/// <inheritdoc />
	public LoginRequestValidator() => RuleFor(x => x.Password)
		.NotEmpty();
}