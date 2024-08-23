using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Repositories.Data;

public abstract class BaseDbContext : DbContext
{
    protected BaseDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().Result;
    }
}