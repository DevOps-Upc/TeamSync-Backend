using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) 
    : IProfileCommandService
{
    public async Task<profile?> Handle(CreateProfileCommand command)
    {
        var project = new profile(command.name,command.address,command.picture, command.company, command.role, command.emailAddress, command.membership);
        //Añadir el repositorio de perfil y igualar el valor de la busqueda
        await profileRepository.AddAsync(project);
        await unitOfWork.CompleteAsync();
        return project;
    }

    public async Task<profile?> Handle(DeleteProfileByIdCommand command)
    {
        var project = await profileRepository.FindByIdAsync(command.projectId);
        profileRepository.Remove(project);
        await unitOfWork.CompleteAsync();
        return project;

    }
}