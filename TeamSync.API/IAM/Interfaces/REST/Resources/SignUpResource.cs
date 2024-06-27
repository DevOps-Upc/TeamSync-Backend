namespace TeamSync.API.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password,string firstname, string lastname, string address, IFormFile picture, int role, string emailAddress,
    string membership);