using Domain;
using FluentValidation;

namespace Application.SubCategories
{
    public class SubCategoryValidator : AbstractValidator<SubCategory>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}