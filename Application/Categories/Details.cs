using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Details
    {
        public class Query : IRequest<Result<Category>>
        {
            public Guid CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Category>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FindAsync(request.CategoryId);

                return Result<Category>.Success(category);
            }
        }
    }
}