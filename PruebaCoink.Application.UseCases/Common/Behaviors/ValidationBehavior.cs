using FluentValidation;
using MediatR;
using PruebaCoink.Application.UseCases.Common.Bases;
using ValidationException = PruebaCoink.Application.UseCases.Common.Exceptions.ValidationException;

namespace PruebaCoink.Application.UseCases.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).Select(x => new BaseError
                {
                    PropertyName = x.PropertyName,
                    ErrorMessage = x.ErrorMessage
                }).ToList();
                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
