using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.Profile.Domain.Model.Aggregates;
using TeamSync.API.Profile.Interfaces.Rest.Resource;

namespace TeamSync.API.Profile.Interfaces.Rest.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(profile profile)
    {
        return new ProfileResource(profile.Id, profile.FirstName,profile.LastName, profile.Address,profile.Picture 
            ,(int)profile.RoleId, profile.EmailAddress, profile.Membership);
    }
 
}