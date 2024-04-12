using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TransactionDetails
{
    public class List
    {
        public class Query : IRequest<Result<List<TransactionDetailDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<TransactionDetailDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<TransactionDetailDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var transactionDetails = await _context.TransactionDetails
                .ProjectTo<TransactionDetailDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<TransactionDetailDto>>.Success(transactionDetails);
            }
        }
    }
}