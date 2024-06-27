using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public class CreateCommentToAddCommentCommandFromResourceAssembler
{
    public static CreateCommentCommand ToCommandFromResource(CreateCommentResource resource)
    {
        return new CreateCommentCommand(resource._content,resource._profileId,resource._projectId);
    }
}