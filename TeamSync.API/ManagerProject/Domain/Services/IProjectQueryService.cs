using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IProjectQueryService
{
    Task<IEnumerable<Project>> Handle(GetAllProjectsByIdProfileQuery query);
    Task<Project?> Handle(GetProjectByIdQuery query);
}