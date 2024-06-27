using Microsoft.EntityFrameworkCore;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.Profile.Domain.Model.Aggregates;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TeamSync.API.Profile.Infrastructure.Persistence.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<profile>(context), IProfileRepository
{

    public new async Task<profile?> FindByIdAsync(int id) =>
        await Context.Set<profile>()
            
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

}