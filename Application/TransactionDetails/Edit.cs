
using Application.Core;
using Application.Validator;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.TransactionDetails
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TransactionDetail TransactionDetail { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TransactionDetail).SetValidator(new TransactionDetailValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var TransactionDetail = await _context.TransactionDetails.FindAsync(request.TransactionDetail.TransactionDetailId);

                if (TransactionDetail == null) return null;

                _mapper.Map(request.TransactionDetail, TransactionDetail);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failure to update the Transaction Detail");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}