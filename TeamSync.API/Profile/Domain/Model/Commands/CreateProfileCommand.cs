namespace TeamSync.API.Profile.Domain.Model.Commands;

public record CreateProfileCommand(string firstname,string lastname, string address, byte[] picture,  string role, string emailAddress, string membership);