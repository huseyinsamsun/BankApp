using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Models;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base("Validation error(s)")
    {
        Errors = errors;
    }
} 