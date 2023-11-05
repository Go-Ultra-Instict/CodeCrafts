using CodeCrafts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDemoDbContext
{
    DbSet<Student> Students { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync2(CancellationToken cancellationToken);
}
