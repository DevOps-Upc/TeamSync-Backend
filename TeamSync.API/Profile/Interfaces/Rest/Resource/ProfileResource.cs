namespace TeamSync.API.Profile.Interfaces.Rest.Resource;

public record ProfileResource(
    int Id ,
    string firstname,
    string lastname,
    string address, 
    byte[] picture, 
    string role, 
    string emailAddress, 
    string membership);