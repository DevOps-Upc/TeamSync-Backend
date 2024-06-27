using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;

namespace TeamSync.API.ManagerProject.Application.Internal.QueryServices;

public class FileAssetQueryService(IFileRepository fileRepository):IFileAssetQueryService
{
    public async Task<IEnumerable<FileAsset>> Handle(GetAllFilesByIdProjectQuery query)
    {
        return await fileRepository.FindByIdProject(query.projectId);
    }

  
}