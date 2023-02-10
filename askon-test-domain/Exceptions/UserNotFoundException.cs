namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public sealed class UserNotFoundException : NotFoundException
{
	/// <inheritdoc />
	public UserNotFoundException(string userId)
		: base($"The user with the identifier {userId} was not found.")
	{
	}
}