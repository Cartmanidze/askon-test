using askon_test_application.Users.Requests;
using FluentValidation;

namespace askon_test_application.Users.Validators;

/// <inheritdoc />
public sealed class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
	/// <inheritdoc />
	public RegistrationRequestValidator() => RuleFor(x => x.Password)
		.NotEmpty();
}