using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;

namespace TeamSync.API.ManagerProject.Application.Internal.QueryServices;

public class CommentQueryService(ICommentRepository commentRepository):ICommentQueryService
{
    public Task<IEnumerable<Comment>> Handle(GetAlllCommentsByIdProjectQuery query)
    {
        return commentRepository.FindByIdProject(query._projectId);
    }
}