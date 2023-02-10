namespace askon_test_domain.Exceptions;

/// <inheritdoc />
public abstract class ApplicationException : Exception
{
	/// <inheritdoc />
	protected ApplicationException(string title, string message)
		: base(message) => Title = title;

	/// <summary>
	/// Тайтл
	/// </summary>
	public string Title { get; }
}