namespace TeamSync.API.Profile.Interfaces.Rest.Resource;

public record CreateProfileResource(string firstname,string lastname, string address, IFormFile  picture, string role, string emailAddress, string membership);