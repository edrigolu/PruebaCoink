using PruebaCoink.Application.UseCases.Common.Bases;

namespace PruebaCoink.Application.UseCases.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base()
        {
            Errors = new List<BaseError>();
        }

        public ValidationException(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }
        public IEnumerable<BaseError>? Errors { get; }
    }
}
