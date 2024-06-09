namespace TeamSync.API.ManagerProject.Domain.Model.Commands;

public record DeleteProjectByIdAndProfileIdCommand(int projectId, int profileId);