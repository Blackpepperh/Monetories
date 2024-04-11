using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.AccountName).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
