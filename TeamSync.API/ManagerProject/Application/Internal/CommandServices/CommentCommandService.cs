using TeamSync.API.ManagerProject.Application.Internal.OutBoundServices;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Application.Internal.CommandServices;

public class CommentCommandService(
    ICommentRepository commentRepository,
    ExternalProfileService externalProfileService,
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork)
:ICommentCommandService
{
    public async Task<Comment?> Handle(CreateCommentCommand command)
    {
        var profileId = externalProfileService.FetchProfileById(command._profileId);
        if(profileId is null) throw new Exception("Profile not found");
        
        var projectId = projectRepository.FindByIdAsync(command._projectId);
        if(projectId is null) throw new Exception("Project not found");
        
        var comment = new Comment(command._content, profileId.Id, projectId.Result);
        await commentRepository.AddAsync(comment);
        await unitOfWork.CompleteAsync();
        return comment;
    }
}