namespace TeamSync.API.Profile.Interfaces.Acl;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstname,string lastname, string address, byte[] picture, string role, string emailAddress, string membership);
    Task<int> FetchProfileId(int id);
}