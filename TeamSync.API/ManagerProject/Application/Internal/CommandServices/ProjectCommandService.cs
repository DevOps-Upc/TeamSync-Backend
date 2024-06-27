using TeamSync.API.ManagerProject.Application.Internal.OutBoundServices;
using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.ManagerProject.Infrastructure.Persistence.Repositories;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository,ExternalProfileService externalProfileService, IUnitOfWork unitOfWork) 
    : IProjectCommandService
{
    public async Task<Project?> Handle(CreateProjectCommand command)
    {
        
        try
        {
            var project = new Project(command.name,command.picture,command.profileId);
            //Añadir el repositorio de perfil y igualar el valor de la 
            var profileId = await externalProfileService.FetchProfileById(command.profileId);
            if(profileId is null) throw new Exception("Profile not found");
        
            await projectRepository.AddAsync(project);
            await unitOfWork.CompleteAsync();
            return project;
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("An error occurred while creating the project. " + e.Message );
            }
        
    }

    private Exception ArgumentExceptionIle(string anErrorOccurredWhileCreatingThePurchaseOrder)
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> Handle(DeleteProjectByIdAndProfileIdCommand command)
    {
        var project = await projectRepository.FindByIdAsync(command.projectId);
        projectRepository.Remove(project);
        await unitOfWork.CompleteAsync();
        return project;

    }
}