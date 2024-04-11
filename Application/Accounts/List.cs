using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Accounts
{
    public class List
    {
        public class Query : IRequest<Result<List<AccountDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<AccountDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AccountDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var accounts = await _context.Accounts
                .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<AccountDto>>.Success(accounts);
            }
        }
    }
}