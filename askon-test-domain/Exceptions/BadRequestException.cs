namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public abstract class BadRequestException : ApplicationException
{
	/// <inheritdoc />
	protected BadRequestException(string message)
		: base("Bad Request", message)
	{
	}
}