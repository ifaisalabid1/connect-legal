using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawFirmRepository(AppDbContext context) : BaseRepository<LawFirm>(context), ILawFirmRepository
{
    public async Task<LawFirm?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
            return null;

        return await _context.LawFirms
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
    }

    public async Task<IEnumerable<LawFirm>?> GetFeaturedAsync(CancellationToken cancellationToken)
    {
        return await _context.LawFirms
            .AsNoTracking()
            .Where(f => f.IsFeatured)
            .OrderByDescending(f => f.CreatedAt)
            .Take(10)
            .ToListAsync(cancellationToken);
    }
}