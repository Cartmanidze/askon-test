using askon_test_application.Profiles.Requests;
using FluentValidation;

namespace askon_test_application.Profiles.Validators;

/// <inheritdoc />
public sealed class EditProfileRequestValidator : AbstractValidator<EditProfileRequest>
{
	/// <inheritdoc />
	public EditProfileRequestValidator() => RuleFor(x => x.NickName)
		.NotEmpty();
}