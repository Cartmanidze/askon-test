using System.Text.Json;
using askon_test_application.Exception;
using askon_test_domain.Exceptions;
using ApplicationException = askon_test_domain.Exceptions.ApplicationException;

namespace askon_test_api.Middleware;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception e)
		{
			await HandleExceptionAsync(context, e);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
	{
		var statusCode = GetStatusCode(exception);

		var response = new
		{
			title = GetTitle(exception),
			status = statusCode,
			detail = exception.Message,
			errors = GetErrors(exception)
		};

		httpContext.Response.ContentType = "application/json";

		httpContext.Response.StatusCode = statusCode;

		await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
	}

	private static int GetStatusCode(Exception exception) => exception switch
	{
		BadRequestException => StatusCodes.Status400BadRequest,
		NotFoundException => StatusCodes.Status404NotFound,
		ValidationException => StatusCodes.Status422UnprocessableEntity,
		var _ => StatusCodes.Status500InternalServerError
	};

	private static string GetTitle(Exception exception) => exception switch
	{
		ApplicationException applicationException => applicationException.Title,
		_ => "Server Error"
	};

	private static IReadOnlyDictionary<string, string[]>? GetErrors(Exception exception)
	{
		IReadOnlyDictionary<string, string[]>? errors = null;

		if (exception is ValidationException validationException)
		{
			errors = validationException.ErrorsDictionary;
		} else
		{
			errors = new Dictionary<string, string[]>
			{
				{
					"Exception", new[]
					{
						exception.Message
					}
				}
			};
		}

		return errors;
	}
}