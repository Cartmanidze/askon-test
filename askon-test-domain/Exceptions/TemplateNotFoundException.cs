namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public sealed class TemplateNotFoundException : NotFoundException
{
	/// <inheritdoc />
	public TemplateNotFoundException(string nickName)
		: base($"The template for the user {nickName} was not found.")
	{
	}
}