using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.Profile.Domain.Model.Aggregates;
using TeamSync.API.Profile.Domain.Model.Queries;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IProfileQueryService
{
    Task<profile?> Handle(GetProfileByIdQuery query);
}