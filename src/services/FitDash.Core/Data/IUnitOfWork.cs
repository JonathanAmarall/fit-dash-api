namespace FitDash.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}