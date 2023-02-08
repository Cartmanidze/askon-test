using askon_test_application.Templates.Requests;
using FluentValidation;

namespace askon_test_application.Templates.Validators;

/// <inheritdoc />
public sealed class EditTemplateRequestValidator : AbstractValidator<EditTemplateRequest>
{
	/// <inheritdoc />
	public EditTemplateRequestValidator()
	{
		RuleFor(x => x.NickName)
			.NotEmpty();

		RuleFor(x => x.Html)
			.NotEmpty();
	}
}