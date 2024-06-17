using Microsoft.AspNetCore.Mvc;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.ManagerProject.Interface.REST.Transform;

namespace TeamSync.API.ManagerProject.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfileController(
    IProfileQueryService profileQueryService,
    IProfileCommandService profileCommandService)
    : ControllerBase
{
    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetProjectById([FromRoute] int projectId)
    {
        var project = await profileQueryService.Handle(new GetProfileByIdQuery(projectId));
        if (project == null) return NotFound();
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(resource);
    }

    [HttpPost]
    [RequestSizeLimit(512*1024*1024)]
    public async Task<IActionResult> CreateProjectByIdProfile([FromForm] CreateProfileResource resource )
    {
        byte[] pictureBytes;
        
        using (var memoryStream = new MemoryStream())
        {
            await resource.picture.CopyToAsync(memoryStream);
            pictureBytes = memoryStream.ToArray();

        }
        
        var createProjectCommand = 
            ProfileToProfileCommandFromResourceAssembler.ToCommandFromResource(resource,pictureBytes);

        var project = await profileCommandService.Handle(createProjectCommand);
        var resourceOk = ProfileResourceFromEntityAssembler.ToResourceFromEntity(project);
        return CreatedAtAction(nameof(GetProjectById), new { projectId = resourceOk.Id }, resourceOk);
    }

    [HttpDelete("{ProjectId}")]
    public async Task<IActionResult> DeleteProject([FromRoute] int ProjectId)
    {
        var deleteProjectByIdAndProfileIdCommand = new DeleteProfileByIdCommand(ProjectId);
        var project = await profileCommandService.Handle(deleteProjectByIdAndProfileIdCommand);
        return Ok(project);
    }
    

    
    
}