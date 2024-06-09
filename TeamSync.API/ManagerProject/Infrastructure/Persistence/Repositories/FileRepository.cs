using Microsoft.EntityFrameworkCore;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;

public class FileRepository(AppDbContext context): BaseRepository<FileAsset>(context),IFileRepository
{
    public new async Task<FileAsset?> FindByIdAsync(int id) =>
        await Context.Set<FileAsset>()
            .Where(f => f.Id == id)
            .FirstOrDefaultAsync();

    public new async Task<IEnumerable<FileAsset>> FindByIdProject(int projectId)
    {
        return await Context.Set<FileAsset>()
            .Where(file => file.Id == projectId)
            .ToListAsync();
    }
}