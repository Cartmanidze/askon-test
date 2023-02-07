using askon_test_dal.Context;
using askon_test_infrastructure.Options;
using askon_test_infrastructure.Services;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace askon_test_infrastructure;

/// <summary>
/// Регистрация сервисов слоя инфраструктуры
/// </summary>
public static class InfrastructureLayerRegistration
{
	/// <summary>
	/// Добавить сервисы для слоя инфраструктуры
	/// </summary>
	/// <param name="services"> Сервисы </param>
	/// <param name="configuration"> Конфигурация </param>
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddOptions<AuthOptions>()
			.Bind(configuration.GetSection(nameof(AuthOptions)));

		services.AddScoped<IJwtGenerator, JwtGenerator>();

		return services;
	}

	/// <summary>
	/// Применение миграции
	/// </summary>
	/// <param name="host">
	/// Экземпляр класса
	/// <see cref="T:Microsoft.Extensions.Hosting.IHost" />
	/// </param>
	public static void UseApplyMigration(this IHost host)
	{
		using var scope = host.Services.CreateScope();

		var dataContext = scope.ServiceProvider.GetRequiredService<AskonContext>();

		dataContext.Database.Migrate();
	}
}