namespace ConnectLegal.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ILawFirmRepository LawFirms { get; }
    ILawyerRepository Lawyers { get; }
    Task<int> CompleteAsync();
}