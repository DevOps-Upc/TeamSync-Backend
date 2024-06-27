using TeamSync.API.Profile.Interfaces.Acl;

namespace TeamSync.API.ManagerProject.Application.Internal.OutBoundServices;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade)
{
    public async Task<int?> FetchProfileById(int id)
    {
        var profileId = await profilesContextFacade.FetchProfileId(id);
        if (profileId == 0) return await Task.FromResult<int?>(null);
        return profileId;
    }
}