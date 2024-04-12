using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class TransactionDetailValidator : AbstractValidator<TransactionDetail>
    {
        public TransactionDetailValidator()
        {
            RuleFor(x => x.TransactionType).NotEmpty();
            RuleFor(x => x.TransactionAmount).NotEmpty();
        }
    }
}
