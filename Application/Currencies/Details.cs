using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Currencies
{
    public class Details
    {
        public class Query : IRequest<Result<Currency>>
        {
            public Guid CurrencyId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Currency>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Currency>> Handle(Query request, CancellationToken cancellationToken)
            {
                var currency = await _context.Currencies.FindAsync(request.CurrencyId);

                return Result<Currency>.Success(currency);
            }
        }
    }
}