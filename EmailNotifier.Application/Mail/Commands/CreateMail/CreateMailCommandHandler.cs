using EmailNotifier.Application.Common;
using EmailNotifier.Application.Interfaces;
using EmailNotifier.EmailService;
using MediatR;

namespace EmailNotifier.Application.Mail.Commands.CreateMail;

public class CreateMailCommandHandler : IRequestHandler<CreateMailCommand, int>
{
    private readonly IEmailNotifierContext _context;
    private readonly EmailSender _sender;

    public CreateMailCommandHandler(IEmailNotifierContext context, EmailSender sender) =>
        (_context, _sender) = (context, sender);

    public async Task<int> Handle(CreateMailCommand request, CancellationToken cancellationToken)
    {
        var entities = new List<Domain.Models.Mail>();
        var recipients = MailListBuilder.BuildRecipientsList(request);
        var status = await _sender.SendEmailRangeAsync(recipients, request.Subject, request.Text);

        if (status == SendStatus.Delivered)
        {
            
            var statusEntity = _context.MailStatuses.FirstOrDefault(x=> x.Name == status.ToString());
                
            if (statusEntity != null)
                foreach (var mail in recipients)
                    entities.Add(new Domain.Models.Mail()
                    {
                        Id = Guid.NewGuid(),
                        MailStatusId = statusEntity.Id,
                        Subject = request.Subject,
                        Text = request.Text,
                        CreationDate = DateTime.Now,
                        Recipient = mail
                    });
        }
        await _context.Mails.AddRangeAsync(entities);
        await _context.SaveChangesAsync(cancellationToken);


        return entities.Count;
    }
}
