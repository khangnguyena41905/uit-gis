namespace GIS.API.Abstractions;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();

    Task SaveChangesAsync();

    Task CommitAsync();

    Task RollbackAsync();

    Task ExecuteInTransactionAsync(Func<Task> action);

    Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action);

    // Add method to get the DbContext
    bool HasChanges();
}