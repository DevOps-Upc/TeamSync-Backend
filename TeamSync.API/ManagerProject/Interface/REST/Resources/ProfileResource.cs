namespace TeamSync.API.ManagerProject.Interface.REST.Resources;

public record ProfileResource(
    int Id ,
    string name, 
    string address, 
    byte[] picture, 
    string company, 
    string role, 
    string emailAddress, 
    string membership);