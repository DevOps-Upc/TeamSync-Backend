using TeamSync.API.ManagerProject.Domain.Model.Entities;

namespace TeamSync.API.ManagerProject.Interface.REST.Resources;

public record ProjectResource(
    int Id ,
    string name, 
    byte[] picture, 
    int profileId);