using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askon_test_application.Exception
{
	public sealed class ValidationException : askon_test_domain.Exceptions.ApplicationException
	{
		public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
			: base("Validation Failure", "One or more validation errors occurred")
			=> ErrorsDictionary = errorsDictionary;

		public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
	}
}
