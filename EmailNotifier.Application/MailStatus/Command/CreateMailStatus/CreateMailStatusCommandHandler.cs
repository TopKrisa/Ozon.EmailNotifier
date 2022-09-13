using EmailNotifier.Application.Interfaces;
using MediatR;

namespace EmailNotifier.Application.MailStatus.Command.CreateMailStatus;

public class CreateMailStatusCommandHandler : IRequestHandler<CreateMailStatusCommand, Guid>
{
    private readonly IEmailNotifierContext _context;
    public CreateMailStatusCommandHandler(IEmailNotifierContext context) =>
        _context = context;

    public async Task<Guid> Handle(CreateMailStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Models.MailStatus()
        {
            Id = request.Id,
            Name = request.Name
        };

        await _context.MailStatuses.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
