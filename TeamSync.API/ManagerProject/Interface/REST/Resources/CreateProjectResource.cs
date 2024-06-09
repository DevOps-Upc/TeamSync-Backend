namespace TeamSync.API.ManagerProject.Interface.REST.Resources;

public record CreateProjectResource(string name,IFormFile picture,int profileId);