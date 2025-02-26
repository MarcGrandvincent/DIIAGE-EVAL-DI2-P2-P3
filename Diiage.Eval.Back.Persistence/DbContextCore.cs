using Microsoft.EntityFrameworkCore;

namespace Diiage.Eval.Back.Persistence;

public class DbContextCore : DbContext
{
    public DbContextCore()
    {
    }

    public DbContextCore(DbContextOptions<DbContextCore> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("backoffice-core");

        builder.ApplyConfigurationsFromAssembly(typeof(DbContextCore).Assembly);
    }
}