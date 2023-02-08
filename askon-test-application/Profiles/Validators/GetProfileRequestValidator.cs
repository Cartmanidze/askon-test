using askon_test_application.Profiles.Requests;
using FluentValidation;

namespace askon_test_application.Profiles.Validators;

/// <inheritdoc />
public sealed class GetProfileRequestValidator : AbstractValidator<GetProfileRequest>
{
	/// <inheritdoc />
	public GetProfileRequestValidator() => RuleFor(x => x.NickName)
		.NotEmpty();
}