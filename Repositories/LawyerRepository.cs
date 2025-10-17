using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawyerRepository(AppDbContext context) : BaseRepository<Lawyer>(context), ILawyerRepository
{
    public async Task<Lawyer?> GetByEmailAsync(string email)
    {
        return await _context.Lawyers.FirstOrDefaultAsync(l => l.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<IEnumerable<Lawyer>?> GetFeaturedAsync()
    {
        return await _context.Lawyers.Where(l => l.IsFeatured).ToListAsync();
    }

    public async Task<Lawyer?> GetByIdWithLawFirmAsync(Guid id)
    {
        return await _context.Lawyers
            .Include(l => l.LawFirm)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Lawyer>?> GetLawyersByLawFirmAsync(Guid lawFirmId)
    {
        return await _context.Lawyers
            .Include(l => l.LawFirm)
            .Where(l => l.LawFirmId == lawFirmId)
            .ToListAsync();
    }
}