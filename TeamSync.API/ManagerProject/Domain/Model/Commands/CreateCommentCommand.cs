namespace TeamSync.API.ManagerProject.Domain.Model.Commands;

public record CreateCommentCommand(string _content,int _profileId,int _projectId);