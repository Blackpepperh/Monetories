using Application.Core;
using MediatR;
using Persistence;

namespace Application.Currencies
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid CurrencyId { get; set; }
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
                var currency = await _context.Categories.FindAsync(request.CurrencyId);

                if (currency == null) return null;

                _context.Remove(currency);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the currency");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}