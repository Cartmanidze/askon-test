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

		builder.Entity<User>()
			.HasData(new()
			{
				Id = Guid.Parse("6EDC3E92-5937-39DB-9CED-4EDA4EA8C121"),
				UserName = "diam",
				NormalizedUserName = "DIAM",
				Email = "diam.lorem@outlook.org",
				NormalizedEmail = "DIAM.LOREM@OUTLOOK.ORG",
				FirstName = "Claudia",
				LastName = "Walls",
				PhoneNumber = "(206) 830-5808",
				PasswordHash = "AQAAAAEAACcQAAAAEMp2ciXjmT/xGKxPbglnV52X3uvTukEI1yZm5dCHW9+dbW5FEEDKp44bSCwp5teaLA==",
				SecurityStamp = "6XFRJNPJGUXVVLV7ZZVWDTWE4NACVWZ4",
				ConcurrencyStamp = "9341a26e-c91a-4633-8ade-fcf24bd12ed5",
				LockoutEnabled = true
			}, new()
			{
				Id = Guid.Parse("F24DC889-9DD8-2223-92A4-8CA677E11914"),
				UserName = "suspendisse",
				NormalizedUserName = "SUSPENDISSE",
				Email = "suspendisse.ac@yahoo.com",
				NormalizedEmail = "SUSPENDISSE.AC@YAHOO.COM",
				FirstName = "Darius",
				LastName = "Freeman",
				PhoneNumber = "(887) 873-7358",
				PasswordHash = "AQAAAAEAACcQAAAAEAuQwjzrDTP1YRIMe9E/D0eRdyz5YpQx6YAfhpgxCuhcyTrX9Vn4NpL8/ndivu0yFg==",
				SecurityStamp = "XD4YMHWL5WU7P7MSYMX3IIJOFUZL7NQL",
				ConcurrencyStamp = "c0e1d55a-d588-4d35-ad81-91abaafa971a",
				LockoutEnabled = true
			});

		builder.Entity<UserInfo>()
			.HasData(new UserInfo
			{
				Id = Guid.Parse("6CC638F4-E49A-4FC1-DD42-8864AA042007"),
				Description = "Test description",
				NickName = "ClWalls",
				BirthDate = new DateTime(1986, 12, 25),
				UserId = Guid.Parse("6EDC3E92-5937-39DB-9CED-4EDA4EA8C121")
			}, new UserInfo
			{
				Id = Guid.Parse("3C8C320E-BC6F-3015-643D-830D2692A9F3"),
				Description = "Test description 2",
				NickName = "DariusF",
				BirthDate = new DateTime(1996, 11, 26),
				UserId = Guid.Parse("F24DC889-9DD8-2223-92A4-8CA677E11914")
			});
	}
}