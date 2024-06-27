using Microsoft.EntityFrameworkCore;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TeamSync.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;

public class CommentRepository(AppDbContext context): BaseRepository<Comment>(context),ICommentRepository
{
    public async Task<IEnumerable<Comment>> FindByIdProject(int id)
    {
        return await Context.Set<Comment>()
            .Where(comment => comment.ProjectId == id)
            .ToListAsync();
    }
}