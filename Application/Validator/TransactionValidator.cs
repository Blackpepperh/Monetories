using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.TransactionDate).NotEmpty();
            RuleFor(x => x.TransactionAmount).NotEmpty();
        }
    }
}