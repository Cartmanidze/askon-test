using askon_test_application.Common.Behaviors;
using askon_test_application.Users.Services;
using askon_test_application.Users.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace askon_test_application;

/// <summary>
/// Регистрация слоя приложения
/// </summary>
public static class ApplicationLayerRegistration
{
	/// <summary>
	/// Добавить слой приложения
	/// </summary>
	/// <param name="services"> Сервисы </param>
	/// <returns> Сервисы </returns>
	public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
	{
		services.AddMediatR(typeof(ApplicationLayerRegistration).Assembly);

		services.AddScoped<IEnemyChecker, EnemyChecker>();

		services.AddValidatorsFromAssembly(typeof(ApplicationLayerRegistration).Assembly, includeInternalTypes: true);

		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}