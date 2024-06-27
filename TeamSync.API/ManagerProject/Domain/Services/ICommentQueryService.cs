using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface ICommentQueryService
{
    Task<IEnumerable<Comment>> Handle(GetAlllCommentsByIdProjectQuery query);
}