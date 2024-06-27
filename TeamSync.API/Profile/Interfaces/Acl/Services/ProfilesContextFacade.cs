using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.Profile.Domain.Model.Queries;

namespace TeamSync.API.Profile.Interfaces.Acl.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):IProfilesContextFacade
{
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