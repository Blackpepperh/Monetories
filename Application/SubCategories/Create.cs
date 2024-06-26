using Application.Core;
using Application.SubCategories;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.SubCategories
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public SubCategory SubCategory { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.SubCategory).SetValidator(new SubCategoryValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.SubCategories.Add(request.SubCategory);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create sub category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}