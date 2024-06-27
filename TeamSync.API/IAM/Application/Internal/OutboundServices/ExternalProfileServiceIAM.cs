using TeamSync.API.Profile.Interfaces.Acl;

namespace TeamSync.API.IAM.Application.Internal.OutboundServices;

public class ExternalProfileServiceIAM(IProfilesContextFacade profilesContextFacade)
{
    public async Task<int?> CreateProfile(string firstname, string lastname, string address, byte[] picture, int role, string emailAddress,
        string membership)
    {
        var profileId = await profilesContextFacade.CreateProfile(firstname,lastname,address,picture,role,emailAddress,membership);
        if (profileId == 0) return await Task.FromResult<int?>(null);
        return profileId;
    }
}