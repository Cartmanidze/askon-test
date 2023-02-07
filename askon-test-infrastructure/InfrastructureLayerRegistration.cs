using askon_test_infrastructure.Options;
using askon_test_infrastructure.Services;
using askon_test_infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
}