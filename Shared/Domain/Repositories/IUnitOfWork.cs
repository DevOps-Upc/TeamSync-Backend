namespace professionals_back_wa.Shared.Domain.Repositories;
public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task CompleteAsync();
}