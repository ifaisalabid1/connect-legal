using ConnectLegal.Data;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectLegal.Repositories;

public class LawyerRepository(AppDbContext context) : Repository<Lawyer>(context), ILawyerRepository
{
    public async Task<Lawyer?> GetByEmailAsync(string email)
    {
        return await _context.Lawyers.FirstOrDefaultAsync(l => l.Email == email);
    }

    public async Task<IEnumerable<Lawyer>?> GetFeaturedAsync()
    {
        return await _context.Lawyers.Where(l => l.IsFeatured).ToListAsync();
    }

    public async Task<IEnumerable<Lawyer>> GetLawyersByLawFirmIdAsync(Guid lawFirmId)
    {
        return await _context.Lawyers.Where(l => l.LawFirmId == lawFirmId).ToListAsync();
    }

    public async Task<bool> LawyerExistsAsync(Guid id)
    {
        return await _context.Lawyers.AnyAsync(l => l.Id == id);
    }
}