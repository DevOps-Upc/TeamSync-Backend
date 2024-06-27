namespace TeamSync.API.Profile.Interfaces.Rest.Resource;

public record ProfileResource(
    int Id ,
    string firstname,
    string lastname,
    string address, 
    byte[] picture, 
    int role, 
    string emailAddress, 
    string membership);