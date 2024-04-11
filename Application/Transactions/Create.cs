using Application.Core;
using Application.Validator;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Transactions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Transaction Transaction { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Transaction).SetValidator(new TransactionValidator());

            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext __context;
            public Handler(DataContext _context)
            {
                __context = _context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                __context.Transactions.Add(request.Transaction);

                var result = await __context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Transaction");

                return Result<Unit>.Success(Unit.Value);
            }
        }






    }
}