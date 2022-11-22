namespace PageApp.Infrastracture.Abstractions;
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
