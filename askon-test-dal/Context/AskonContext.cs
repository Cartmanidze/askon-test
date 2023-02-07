using askon_test_domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace askon_test_dal.Context;

/// <inheritdoc />
public class AskonContext : IdentityDbContext<User>
{
}