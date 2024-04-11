using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class TransactionHeaderValidator : AbstractValidator<TransactionHeader>
    {
        public TransactionHeaderValidator()
        {
            RuleFor(x => x.TransactionDate).NotEmpty();
            RuleFor(x => x.AccountId).NotEmpty();
        }
    }
}
