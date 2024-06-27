using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IFileAssetQueryService
{
    Task<IEnumerable<FileAsset>> Handle(GetAllFilesByIdProjectQuery query);
    
}