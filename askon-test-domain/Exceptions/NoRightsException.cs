namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public class NoRightsException : ApplicationException
{
	/// <inheritdoc />
	public NoRightsException(string message) : base("Not rights", message)
	{
	}
}