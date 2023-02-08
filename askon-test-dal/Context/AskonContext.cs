using askon_test_domain.Templates;
using askon_test_domain.Users;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Context;

/// <inheritdoc />
public class AskonContext : DbContext
{
	/// <inheritdoc />
	public AskonContext(DbContextOptions<AskonContext> options) : base(options)
	{
	}

	/// <summary>
	/// Пользователи
	/// </summary>
	public DbSet<User> Users { get; set; } = null!;

	/// <summary>
	/// Информация о пользователе
	/// </summary>
	public DbSet<UserInfo> UserInfo { get; set; } = null!;

	/// <summary>
	/// Шаблоны
	/// </summary>
	public DbSet<Template> Templates { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<User>()
			.HasOne(a => a.UserInfo)
			.WithOne(a => a.User)
			.HasForeignKey<UserInfo>(c => c.UserId);

		builder.Entity<UserInfo>()
			.HasOne(a => a.Template)
			.WithOne(a => a.UserInfo)
			.HasForeignKey<Template>(c => c.UserInfoId);

		builder.Entity<User>()
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();

		builder.Entity<UserInfo>()
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();

		builder.Entity<Template>()
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();
	}
}