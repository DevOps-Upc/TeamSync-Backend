using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public class CreateFileToAddFileCommandFromResourceAssembler
{
    public static AddNewFileToProjectCommand ToCommandFromResource(CreateFileResource resource)
    {
        byte[] fileBytes;
        
        using (var memoryStream = new MemoryStream())
        {
            resource.file.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();

        }
        
        return new AddNewFileToProjectCommand(
            fileBytes,
            resource.file.FileName,
            resource.file.ContentType,
            resource.projectId);
        
        
        
    }
}