using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TransactionHeaders
{
    public class List
    {
        public class Query : IRequest<Result<List<TransactionHeaderDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<TransactionHeaderDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<TransactionHeaderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var transactionHeaders = await _context.TransactionHeaders
                .ProjectTo<TransactionHeaderDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<TransactionHeaderDto>>.Success(transactionHeaders);
            }
        }
    }
}