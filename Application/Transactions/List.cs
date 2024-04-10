using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Transactions
{
    public class List
    {
        public class Query : IRequest<Result<List<TransactionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<TransactionDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<TransactionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var transactions = await _context.Transactions
                .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<TransactionDto>>.Success(transactions);
            }
        }
    }
}