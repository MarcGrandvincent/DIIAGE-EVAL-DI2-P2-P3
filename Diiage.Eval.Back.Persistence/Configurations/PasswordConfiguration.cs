using Diiage.Eval.Back.Domain.Entities.Applications;
using Diiage.Eval.Back.Domain.Entities.Passwords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diiage.Eval.Back.Persistence.Configurations;

public class PasswordConfiguration : IEntityTypeConfiguration<PasswordDao>
{
    public void Configure(EntityTypeBuilder<PasswordDao> builder)
    {
        builder.ToTable(TablesNames.PasswordTables.Passwords);

        builder.HasKey(b => b.Id);

        builder.Property(b => b.EncryptedPassword);
        
        builder.Property(b => b.IV);
        
        builder.HasOne(e => e.Application)
            .WithMany(e => e.Passwords)
            .HasForeignKey(e => e.ApplicationId);
    }
}
