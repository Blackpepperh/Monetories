using Domain;
using FluentValidation;

namespace Application.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
