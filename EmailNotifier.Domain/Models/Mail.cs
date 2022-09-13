namespace EmailNotifier.Domain.Models;

public class Mail : BaseModel
{
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Text { get; set; }
    public Guid MailStatusId { get; set; }
    public DateTime CreationDate { get; set; }
}
