namespace TeamSync.API.ManagerProject.Domain.Model.Commands;

public record CreateProjectCommand(string name, byte[] picture, int profileId);
