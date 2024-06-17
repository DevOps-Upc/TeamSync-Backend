namespace TeamSync.API.ManagerProject.Domain.Model.Commands;

public record CreateProfileCommand(string name, string address, byte[] picture, string company, string role, string emailAddress, string membership);