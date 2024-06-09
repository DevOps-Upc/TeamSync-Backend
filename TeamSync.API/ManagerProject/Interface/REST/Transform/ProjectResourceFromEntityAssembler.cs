using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public static class ProjectResourceFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Project project)
    {
        return new ProjectResource(project.Id, project.Name, project.Picture, project.ProfileId);
    }
    
}