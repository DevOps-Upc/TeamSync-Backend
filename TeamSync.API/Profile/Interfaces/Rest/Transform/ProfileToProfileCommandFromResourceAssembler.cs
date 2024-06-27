using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.Profile.Domain.Model.Commands;
using TeamSync.API.Profile.Interfaces.Rest.Resource;

namespace TeamSync.API.Profile.Interfaces.Rest.Transform;

public class ProfileToProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource,byte[] picture)
    {
        
        
        return new CreateProfileCommand(
            resource.firstname,
            resource.lastname,
            resource.address,
            picture, 
            resource.role,
            resource.emailAddress,
            resource.membership);
    }
}