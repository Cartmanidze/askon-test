namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public abstract class NotFoundException : ApplicationException
{
	/// <inheritdoc />
	protected NotFoundException(string message)
		: base("Not Found", message)
	{
	}
}