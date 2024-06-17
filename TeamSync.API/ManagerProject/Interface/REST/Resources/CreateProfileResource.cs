namespace TeamSync.API.ManagerProject.Interface.REST.Resources;

public record CreateProfileResource(string name, string address, IFormFile  picture, string company, string role, string emailAddress, string membership);