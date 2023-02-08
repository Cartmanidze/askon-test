using askon_test_dal.Context;
using askon_test_dal.Repositories.ReadOnly;
using askon_test_dal.Repositories.WriteOnly;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_domain.Users.Repositories.WriteOnly;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace askon_test_dal;

/// <summary>
/// Регистрация слоя данных
/// </summary>
public static class DataAccessLayerRegistration
{
	/// <summary>
	/// Добавить сервисы для слоя данных
	/// </summary>
	/// <param name="services"> Сервисы </param>
	/// <param name="configuration"> Конфигурация приложения </param>
	public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
	{
		void OptionsAction(DbContextOptionsBuilder builder) => builder.UseSqlServer(configuration.GetConnectionString("AskonConnection"));

		services.AddDbContext<AskonContext>((Action<DbContextOptionsBuilder>) OptionsAction, ServiceLifetime.Singleton);

		services.AddPooledDbContextFactory<AskonContext>(OptionsAction);

		services.AddIdentity<User, IdentityRole<Guid>>(options =>
			{
				options.User.RequireUniqueEmail = false;
			})
			.AddEntityFrameworkStores<AskonContext>()
			.AddDefaultTokenProviders()
			.AddSignInManager<SignInManager<User>>();

		services.AddScoped<IUserInfoReadOnlyRepository, UserInfoReadOnlyRepository>();

		services.AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>();

		services.AddScoped<IUserInfoWriteOnlyRepository, UserInfoWriteOnlyRepository>();

		return services;
	}
}