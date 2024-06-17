using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(profile profile)
    {
        return new ProfileResource(profile.Id, profile.Name, profile.Address,profile.Picture, 
            profile.Company,profile.Role, profile.EmailAddress, profile.Membership);
    }
 
}