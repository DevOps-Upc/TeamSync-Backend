namespace TeamSync.API.ManagerProject.Interface.REST.Resources;

public record FileAssetResource(
    int id,
    byte[] datafile,
    string _name,
    string _type,
    int _projectId);