using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawyerRepository(AppDbContext context) : BaseRepository<Lawyer>(context), ILawyerRepository
{
    public async Task<Lawyer?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
            return null;

        return await _context.Lawyers
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase), cancellationToken);

    }

    public async Task<IEnumerable<Lawyer>?> GetFeaturedAsync(CancellationToken cancellationToken)
    {
        return await _context.Lawyers
            .AsNoTracking()
            .Where(l => l.IsFeatured)
            .OrderByDescending(l => l.CreatedAt)
            .Take(10)
            .ToListAsync(cancellationToken);
    }
}