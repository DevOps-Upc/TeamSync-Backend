using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.Profile.Domain.Model.Commands;
using TeamSync.API.Profile.Domain.Model.Queries;

namespace TeamSync.API.Profile.Interfaces.Acl.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstname, string lastname, string address, byte[] picture, int role, string emailAddress,
        string membership)
    {
        var createProfileCommand =
            new CreateProfileCommand(firstname, lastname, address, picture, role, emailAddress, membership);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
        
    }

    public Task<int> CreateProfile(string firstname, string lastname, string address, byte[] picture, string role, string emailAddress,
        string membership)
    {
        throw new NotImplementedException();
    }

    public async Task<int> FetchProfileId(int id)
    {
        var getProfileById = new GetProfileByIdQuery(id);
        var profile = await profileQueryService.Handle(getProfileById);
        return profile?.Id ?? 0;
    }
}