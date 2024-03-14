using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.SubCategories
{
    public class Edit
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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var SubCategory = await _context.SubCategories.FindAsync(request.SubCategory.Id);

                if (SubCategory == null) return null;

                _mapper.Map(request.SubCategory, SubCategory);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failure to update the Sub Category");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}