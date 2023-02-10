using ApplicationException = askon_test_domain.Exceptions.ApplicationException;

namespace askon_test_application.Exception;

/// <inheritdoc />
public sealed class ValidationException : ApplicationException
{
	/// <inheritdoc />
	public ValidationException(IReadOnlyDictionary<string, string[]>? errorsDictionary)
		: base("Validation Failure", "One or more validation errors occurred") => ErrorsDictionary = errorsDictionary;

	/// <summary>
	/// Ошибки
	/// </summary>
	public IReadOnlyDictionary<string, string[]>? ErrorsDictionary { get; }
}