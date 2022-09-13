using MediatR;

namespace EmailNotifier.Application.MailStatus.Command.CreateMailStatus;

public class CreateMailStatusCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
