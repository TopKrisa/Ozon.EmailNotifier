using MediatR;

namespace EmailNotifier.Application.Mail.Commands.CreateMail;

public class CreateMailCommand : IRequest<int>
{
    public Guid Id { get; set; }
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public List<string>? CarbonCopyRecipient { get; set; }
}
