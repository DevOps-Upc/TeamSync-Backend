namespace TeamSync.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task CompleteAsync();
}