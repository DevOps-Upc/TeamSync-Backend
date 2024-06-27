namespace TeamSync.API.Profile.Interfaces.Rest.Resource;

public record CreateProfileResource(string firstname,string lastname, string address, IFormFile  picture, int role, string emailAddress, string membership);