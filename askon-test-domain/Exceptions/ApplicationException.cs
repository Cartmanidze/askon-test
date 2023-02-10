using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askon_test_domain.Exceptions
{
	public abstract class ApplicationException : Exception
	{
		protected ApplicationException(string title, string message)
			: base(message) =>
			Title = title;

		public string Title { get; }
	}
}