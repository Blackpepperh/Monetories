using Domain;
using FluentValidation;

public class TransactionValidator : AbstractValidator<Transaction>
{
    public TransactionValidator()
    {
        RuleFor(x => x.TransactionDate).NotEmpty();
        RuleFor(x => x.TransactionAmount).NotEmpty();
    }
}