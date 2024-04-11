
using Application.Core;
using Application.Validator;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Accounts
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Account Account { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Account).SetValidator(new AccountValidator());
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
                var Account = await _context.Accounts.FindAsync(request.Account.AccountId);

                if (Account == null) return null;

                _mapper.Map(request.Account, Account);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failure to update the Account");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}