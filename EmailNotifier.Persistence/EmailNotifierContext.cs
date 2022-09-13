using EmailNotifier.Application.Interfaces;
using EmailNotifier.Domain.Models;
using EmailNotifier.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EmailNotifier.Persistence;

public class EmailNotifierContext : DbContext, IEmailNotifierContext
{
    public DbSet<Mail> Mails { get; set; }
    public DbSet<MailStatus> MailStatuses { get; set; }
    public EmailNotifierContext(DbContextOptions<EmailNotifierContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MailConfiguration());
    }
}
