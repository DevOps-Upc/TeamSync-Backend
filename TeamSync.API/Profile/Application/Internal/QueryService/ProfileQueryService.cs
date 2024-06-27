using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Queries;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.Profile.Domain.Model.Aggregates;
using TeamSync.API.Profile.Domain.Model.Queries;

namespace TeamSync.API.Profile.Application.Internal.QueryService
{
    public class ProfileQueryService : IProfileQueryService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileQueryService(IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;
        }


        public async Task<profile?> Handle(GetProfileByIdQuery query)
        {
            return await _profileRepository.FindByIdAsync(query.Id);
        }
    }
}