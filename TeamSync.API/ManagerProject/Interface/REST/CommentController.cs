using Microsoft.AspNetCore.Mvc;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Interface.REST.Resources;
using TeamSync.API.ManagerProject.Interface.REST.Transform;

namespace TeamSync.API.ManagerProject.Interface;

[ApiController]
[Route("api/v1/[controller]")]
public class CommentController(ICommentCommandService commentCommandService,ICommentQueryService commentQueryService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCommentProjectId([FromBody] CreateCommentResource resource)
    {
        var createCommentCommand =
            CreateCommentToAddCommentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var comment = commentCommandService.Handle(createCommentCommand);
        return Ok(comment.Result);
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetAllFilesByIdProject([FromRoute] int projectId)
    {
        var getAllCommentByIdProjectQuery = new GetAlllCommentsByIdProjectQuery(projectId);
        var comments = await commentQueryService.Handle(getAllCommentByIdProjectQuery);
        var resources = comments.Select(CommentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
        /*
        var files = await fileAssetQueryService.Handle(getAllFilesByIdProjectQuery);
        var resources = files.Select(FileAssetResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);*/
    }
    
}