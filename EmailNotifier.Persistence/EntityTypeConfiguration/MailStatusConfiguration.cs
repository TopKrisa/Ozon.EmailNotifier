using EmailNotifier.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailNotifier.Persistence.EntityTypeConfiguration;

public class MailStatusConfiguration : IEntityTypeConfiguration<MailStatus>
{
    public void Configure(EntityTypeBuilder<MailStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(10).IsRequired();
    }
}
