using Microsoft.EntityFrameworkCore;
using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<Project>(context), IProjectRepository
{
    public async Task<IEnumerable<Project>> FindByProfileIdAsync(int profileId)
    {
        return await Context.Set<Project>()
            .Where(project => project.ProfileId == profileId)
            .ToListAsync();
    }

    public new async Task<Project?> FindByIdAsync(int id) =>
        await Context.Set<Project>()
            
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
}
