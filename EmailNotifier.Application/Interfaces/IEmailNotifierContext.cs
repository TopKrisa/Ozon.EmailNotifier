using Microsoft.EntityFrameworkCore;

namespace EmailNotifier.Application.Interfaces;

public interface IEmailNotifierContext
{
    public DbSet<Domain.Models.Mail> Mails { get; set; }
    public DbSet<Domain.Models.MailStatus> MailStatuses { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
