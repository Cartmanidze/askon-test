﻿using MediatR;
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
	public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services) =>
		services.AddMediatR(typeof(ApplicationLayerRegistration).Assembly);
}