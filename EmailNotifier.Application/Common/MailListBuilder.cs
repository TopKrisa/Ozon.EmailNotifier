using EmailNotifier.Application.Mail.Commands.CreateMail;

namespace EmailNotifier.Application.Common;

public static class MailListBuilder
{
    public static IList<string> BuildRecipientsList(CreateMailCommand request)
    {
        var entities = new List<string>();
        entities.Add(request.Recipient);
        request.CarbonCopyRecipient?.ForEach(recipient =>
        {
            entities.Add(recipient);
        });
        return entities.ToList();
    }
}
