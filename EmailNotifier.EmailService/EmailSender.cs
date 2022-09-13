using MailKit;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmailNotifier.EmailService;

public class EmailSender
{
    private readonly string _host;
    private readonly int _port;
    private readonly bool _useSSL;
    private readonly string _login;
    private readonly string _password;

    public EmailSender(EmailSenderOptions options)
    {
        _host = options.Host;
        _port = options.Port;
        _useSSL = options.UseSSL;
        _login = options.Login;
        _password = options.Password;
    }

    public async Task<SendStatus> SendEmailRangeAsync(IList<string> emails, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        var emailsList = new List<MailboxAddress>();

        foreach (var email in emails)
            emailsList.Add(new MailboxAddress(email, email));

        emailMessage.From.Add(new MailboxAddress("Администрация сайта", _login));
        emailMessage.To.AddRange(emailsList);
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };
        return await SendRangeMessages(emailMessage);
    }
    private async Task<SendStatus> SendRangeMessages(MimeMessage message)
    {
        try
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_host, _port, _useSSL);
                await client.AuthenticateAsync(_login, _password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            return SendStatus.Delivered;
        }
        catch (ServiceNotAuthenticatedException)
        {
            return SendStatus.Failure;
        }
    }
}
