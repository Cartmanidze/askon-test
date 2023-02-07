using askon_test_domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Context;

/// <inheritdoc />
public class AskonContext : IdentityDbContext<User>
{
	public DbSet<UserInfo> UserInfo { get; set; }
}