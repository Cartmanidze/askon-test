using askon_test_domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Context;

/// <inheritdoc />
public class AskonContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	/// <summary>
	/// Информация о пользователе
	/// </summary>
	public DbSet<UserInfo> UserInfo { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=askon;Trusted_Connection=True;");
	}

	/// <inheritdoc />
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<User>()
			.HasOne(a => a.UserInfo)
			.WithOne(a => a.User)
			.HasForeignKey<UserInfo>(c => c.UserId);
	}
}