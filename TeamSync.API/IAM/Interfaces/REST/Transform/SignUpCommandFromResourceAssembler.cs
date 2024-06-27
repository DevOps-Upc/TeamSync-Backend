using TeamSync.API.IAM.Domain.Model.Commands;
using TeamSync.API.IAM.Interfaces.REST.Resources;

namespace TeamSync.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        byte[] fileBytes;
        
        using (var memoryStream = new MemoryStream())
        {
            resource.picture.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();

        }
        return new SignUpCommand(
            resource.Username, 
            resource.Password,
            resource.firstname,
            resource.lastname,
            resource.address,
            fileBytes,
            resource.role,
            resource.emailAddress,
            resource.membership);
    }
}