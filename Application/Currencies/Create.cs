using Application.Core;
using Application.Validator;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Currencies
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Currency Currency { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Currency).SetValidator(new CurrencyValidator());
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
                _context.Currencies.Add(request.Currency);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create Currency");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}