using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository, IUnitOfWork unitOfWork) 
    : IProjectCommandService
{
    public async Task<Project?> Handle(CreateProjectCommand command)
    {
        var project = new Project(command.name,command.picture,command.profileId);
        //Añadir el repositorio de perfil y igualar el valor de la busqueda
        await projectRepository.AddAsync(project);
        await unitOfWork.CompleteAsync();
        return project;
    }
    
}