using Application.Categories;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SubCategories
{
    public class List
    {
        public class Query : IRequest<Result<List<SubCategoryDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<SubCategoryDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<SubCategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var subcategories = await _context.SubCategories
                    .ProjectTo<SubCategoryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<SubCategoryDto>>.Success(subcategories);
            }
        }

    }
}