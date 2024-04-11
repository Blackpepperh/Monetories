using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(x => x.CurrencyName).NotEmpty();
            RuleFor(x => x.CurrencySymbol).NotEmpty().MaximumLength(3);
            RuleFor(x => x.CurrencyOrigin).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
