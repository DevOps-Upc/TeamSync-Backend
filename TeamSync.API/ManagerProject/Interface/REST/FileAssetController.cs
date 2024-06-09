using Microsoft.AspNetCore.Mvc;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.ManagerProject.Interface.REST.Transform;

namespace TeamSync.API.ManagerProject.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class FileAssetController(
    IFileAssetCommandService fileAssetCommandService,
    IFileAssetQueryService fileAssetQueryService)
    :ControllerBase
{
    [HttpPost]
    [RequestSizeLimit(10*1024*1024)]
    public async Task<IActionResult> AddFileByProjectId([FromForm] CreateFileResource resource)
    {
        var addNewFileToProjectcommand =
            CreateFileToAddFileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var fileAsset = fileAssetCommandService.Handle(addNewFileToProjectcommand);
        return Ok(fileAsset.Result);
        
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetAllFilesByIdProject([FromRoute] int projectId)
    {
        var getAllFilesByIdProjectQuery = new GetAllFilesByIdProjectQuery(projectId);
        var files = await fileAssetQueryService.Handle(getAllFilesByIdProjectQuery);
        var resources = files.Select(FileAssetResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}