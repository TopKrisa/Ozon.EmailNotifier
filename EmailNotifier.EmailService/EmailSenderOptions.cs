namespace EmailNotifier.EmailService;

public class EmailSenderOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool UseSSL { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
