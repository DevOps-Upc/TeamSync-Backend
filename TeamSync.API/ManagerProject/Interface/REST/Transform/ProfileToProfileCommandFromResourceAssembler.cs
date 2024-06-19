using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public class ProfileToProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource,byte[] picture)
    {
        
        
        return new CreateProfileCommand(
            resource.name,
            resource.address,
            picture, 
            resource.company,
            resource.role,
            resource.emailAddress,
            resource.membership);
    }
}