using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Domain.Repositories;

public interface ICommentRepository:IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> FindByIdProject(int id);
}