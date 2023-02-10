using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askon_test_domain.Exceptions
{
	public sealed class UserNotFoundException : NotFoundException
	{
		public UserNotFoundException(string userId)
			: base($"The user with the identifier {userId} was not found.")
		{
		}
	}
}
