using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.SubCategories
{
    public class Details
    {
        public class Query : IRequest<Result<SubCategory>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SubCategory>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<SubCategory>> Handle(Query request, CancellationToken cancellationToken)
            {
                var SubCategory = await _context.SubCategories.FindAsync(request.Id);

                return Result<SubCategory>.Success(SubCategory);
            }
        }
    }
}