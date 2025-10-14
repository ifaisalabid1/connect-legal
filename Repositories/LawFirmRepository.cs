using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawFirmRepository(AppDbContext context) : Repository<LawFirm>(context), ILawFirmRepository
{
    public async Task<LawFirm?> GetByEmailAsync(string email)
    {
        return await _context.LawFirms.FirstOrDefaultAsync(f => f.Email == email);
    }

    public async Task<IEnumerable<LawFirm>?> GetFeaturedAsync()
    {
        return await _context.LawFirms.Where(f => f.IsFeatured).ToListAsync();
    }

    public async Task<bool> LawFirmExistsAsync(Guid id)
    {
        return await _context.LawFirms.AnyAsync(f => f.Id == id);
    }
}