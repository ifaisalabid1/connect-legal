using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawFirmRepository(AppDbContext context) : BaseRepository<LawFirm>(context), ILawFirmRepository
{
    public async Task<LawFirm?> GetByEmailAsync(string email)
    {
        return await _context.LawFirms.FirstOrDefaultAsync(f => f.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<LawFirm?> GetByIdWithLawyersAsync(Guid id)
    {
        return await _context.LawFirms
            .Include(f => f.Lawyers)
            .FirstOrDefaultAsync(f => f.Id == id);


    }

    public async Task<IEnumerable<LawFirm>?> GetFeaturedAsync()
    {
        return await _context.LawFirms.Where(f => f.IsFeatured).ToListAsync();
    }
}