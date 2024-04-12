using Application.Core;
using Application.Validator;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.TransactionHeaders
{
    public class Create
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
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.TransactionHeaders.Add(request.TransactionHeader);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Transaction Header");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}