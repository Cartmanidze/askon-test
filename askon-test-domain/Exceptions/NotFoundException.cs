using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askon_test_domain.Exceptions
{
	public abstract class NotFoundException : ApplicationException
	{
		protected NotFoundException(string message)
			: base("Not Found", message)
		{
		}
	}
}
