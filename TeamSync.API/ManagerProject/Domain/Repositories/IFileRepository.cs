using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.Shared.Domain.Repositories;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TeamSync.API.ManagerProject.Domain.Repositories;

public interface IFileRepository: IBaseRepository<FileAsset>
{
    Task<IEnumerable<FileAsset>> FindByIdProject(int projectId);
}