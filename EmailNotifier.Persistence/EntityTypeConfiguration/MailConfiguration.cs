using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmailNotifier.Domain.Models;

namespace EmailNotifier.Persistence.EntityTypeConfiguration;

public class MailConfiguration : IEntityTypeConfiguration<Mail>
{
    public void Configure(EntityTypeBuilder<Mail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Subject).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Text).IsRequired();
        builder.Property(x => x.CreationDate).IsRequired();
        builder.HasOne(typeof(MailStatus));
    }
}
