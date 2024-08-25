using Microsoft.EntityFrameworkCore;

namespace EXE201.SmartThrive.Data.Context;

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