using askon_test_dal.Context;
using askon_test_domain.Users;
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
		services.AddDbContext<AskonContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("AskonConnection")));

		services.AddIdentity<User, IdentityRole<Guid>>(options =>
			{
				options.User.RequireUniqueEmail = false;
			})
			.AddEntityFrameworkStores<AskonContext>()
			.AddDefaultTokenProviders()
			.AddSignInManager<SignInManager<User>>();

		return services;
	}
}