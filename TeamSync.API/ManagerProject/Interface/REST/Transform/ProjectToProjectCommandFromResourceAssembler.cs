using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public class ProjectToProjectCommandFromResourceAssembler
{
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource resource,byte[] picture)
    {
        
        
        return new CreateProjectCommand(
            resource.name,
            picture, 
            resource.profileId);
    }
    
}