using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Currencies
{
    public class List
    {
        public class Query : IRequest<Result<List<CurrencyDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<CurrencyDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<CurrencyDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var currencies = await _context.Currencies
                    .ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<CurrencyDto>>.Success(currencies);
            }
        }
    }
}