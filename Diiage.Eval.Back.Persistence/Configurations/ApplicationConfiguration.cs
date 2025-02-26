using Diiage.Eval.Back.Domain.Entities.Applications;
using Diiage.Eval.Back.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diiage.Eval.Back.Persistence.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationDao>
{
    public void Configure(EntityTypeBuilder<ApplicationDao> builder)
    {
        builder.ToTable(TablesNames.ApplicationsTables.Applications);

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name);

        builder.HasDiscriminator(b => b.ApplicationType)
            .HasValue<ApplicationProfessionalDao>(ApplicationType.Professional)
            .HasValue<ApplicationPublicDao>(ApplicationType.Public);
    }
}
