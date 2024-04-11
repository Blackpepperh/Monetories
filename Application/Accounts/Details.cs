using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Accounts
{
    public class Details
    {
        public class Query : IRequest<Result<Account>>
        {
            public Guid AccountId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Account>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Account>> Handle(Query request, CancellationToken cancellationToken)
            {
                var account = await _context.Accounts.FindAsync(request.AccountId);

                return Result<Account>.Success(account);
            }
        }
    }
}