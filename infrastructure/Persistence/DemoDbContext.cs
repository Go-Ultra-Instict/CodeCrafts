using Application.Interfaces;
using CodeCrafts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DemoDbContext : DbContext, IDemoDbContext
{

    public DbSet<Student> Students => Set<Student>();
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {
    }

    public async Task<int> SaveChangesAsync2(CancellationToken cancellationToken)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}
