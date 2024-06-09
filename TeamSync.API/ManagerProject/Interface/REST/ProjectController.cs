using Microsoft.AspNetCore.Mvc;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.ManagerProject.Interface.REST.Transform;

namespace TeamSync.API.ManagerProject.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProjectController(
    IProjectQueryService projectQueryService,
    IProjectCommandService projectCommandService)
    : ControllerBase
{
    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectById([FromRoute] int projectId)
    {
        var project = await projectQueryService.Handle(new GetProjectByIdQuery(projectId));
        if (project == null) return NotFound();
        var resource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(resource);
    }

    [HttpGet("profile/{profileId}")]
    public async Task<IActionResult> GetAllProjectByProfileId([FromRoute] int profileId)
    {
        var getAllProjectByIdProfile = new GetAllProjectsByIdProfileQuery(profileId);
        var projects = await projectQueryService.Handle(getAllProjectByIdProfile);
        var resources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPost]
    [RequestSizeLimit(512*1024*1024)]
    public async Task<IActionResult> CreateProjectByIdProfile([FromForm] CreateProjectResource resource )
    {
        byte[] pictureBytes;
        
        using (var memoryStream = new MemoryStream())
        {
            await resource.picture.CopyToAsync(memoryStream);
            pictureBytes = memoryStream.ToArray();

        }
        
        var createProjectCommand = 
            ProjectToProjectCommandFromResourceAssembler.ToCommandFromResource(resource,pictureBytes);

        var project = await projectCommandService.Handle(createProjectCommand);
        var resourceOk = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return CreatedAtAction(nameof(GetProjectById), new { projectId = resourceOk.Id }, resourceOk);
    }

    [HttpDelete("{ProjectId}/{ProfileId}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int ProjectId, int ProfileId)
    {
        var deleteProjectByIdAndProfileIdCommand = new DeleteProjectByIdAndProfileIdCommand(ProjectId, ProfileId);
        var project = await projectCommandService.Handle(deleteProjectByIdAndProfileIdCommand);
        return Ok(project);
    }
    

    
    
}