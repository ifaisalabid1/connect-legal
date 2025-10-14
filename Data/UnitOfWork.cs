using ConnectLegal.Interfaces;
using ConnectLegal.Repositories;

namespace ConnectLegal.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ILawFirmRepository LawFirms { get; private set; }
    public ILawyerRepository Lawyers { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        LawFirms = new LawFirmRepository(_context);
        Lawyers = new LawyerRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}