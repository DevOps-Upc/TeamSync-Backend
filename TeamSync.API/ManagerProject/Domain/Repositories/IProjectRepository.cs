using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Domain.Repositories;

public interface IProjectRepository:IBaseRepository<Project>
{
    Task<IEnumerable<Project>> FindByProfileIdAsync(int profileId);
    
}