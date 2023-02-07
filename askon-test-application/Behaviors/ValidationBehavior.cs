using MediatR;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace askon_test_application.Behaviors
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TRequest"></typeparam>
	/// <typeparam name="TResponse"></typeparam>
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : MediatR.IRequest<TResponse>
	{
		private readonly IValidator<TRequest> _validator;

		public ValidationBehavior(IValidator<TRequest> validator)
		{
			_validator = validator;
		}

		public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			_validator.ValidateAndThrow(request);
			return next();
		}
	}
}
