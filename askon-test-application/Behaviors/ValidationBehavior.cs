using FluentValidation;
using MediatR;

namespace askon_test_application.Behaviors;

/// <inheritdoc />
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly IValidator<TRequest> _validator;

	/// <summary>
	/// .ctor
	/// </summary>
	public ValidationBehavior(IValidator<TRequest> validator) => _validator = validator;

	/// <inheritdoc />
	public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_validator.ValidateAndThrow(request);

		return next();
	}
}