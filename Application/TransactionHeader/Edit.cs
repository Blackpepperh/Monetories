
using Application.Core;
using Application.Validator;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.TransactionHeaders
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TransactionHeader TransactionHeader { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TransactionHeader).SetValidator(new TransactionHeaderValidator());
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
                var TransactionHeader = await _context.TransactionHeaders.FindAsync(request.TransactionHeader.TransactionHeaderId);

                if (TransactionHeader == null) return null;

                _mapper.Map(request.TransactionHeader, TransactionHeader);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failure to update the TransactionHeader");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}