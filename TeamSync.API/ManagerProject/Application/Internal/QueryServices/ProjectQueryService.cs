using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;

namespace TeamSync.API.ManagerProject.Application.Internal.QueryServices
{
    public class ProjectQueryService : IProjectQueryService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectQueryService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(GetAllProjectsByIdProfileQuery query)
        {
            return await projectRepository.FindByProfileIdAsync(query.ProfileId);
        }

        public async Task<Project?> Handle(GetProjectByIdQuery query)
        {
            return await projectRepository.FindByIdAsync(query.Id);
        }
    }
}