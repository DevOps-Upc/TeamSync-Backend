using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public class CommentResourceFromEntityAssembler
{
    public static CommentResource ToResourceFromEntity(Comment entity)
    {
        return new CommentResource(
            entity.Id,
            entity.content,
            entity.profileId,
            entity.ProjectId);
    }
}