using System.Runtime.Serialization;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Domain.Repositories;
using TeamSync.API.ManagerProject.Domain.Services;
using TeamSync.API.Shared.Domain.Repositories;

namespace TeamSync.API.ManagerProject.Application.Internal.CommandServices;

public class FileAssetCommandService
    (IFileRepository fileRepository,
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    :IFileAssetCommandService
{
    public async Task<FileAsset?> Handle(AddNewFileToProjectCommand command)
    {
        if (command.datafile is null || command.datafile.Length == 0) throw new Exception("The file is null or empty");

        var project = await projectRepository.FindByIdAsync(command._projectId);
        if (project is null) throw new Exception("The project dont exist ");
        
        
        var fileAsset = new FileAsset(command.datafile, command._name, command._type, project);
        project.Files.Add(fileAsset);
        
        
        //await fileRepository.AddAsync(fileAsset);
        await unitOfWork.CompleteAsync();
        return fileAsset;
        
        
        /*
        var project = new Project(command.name,command.picture,command.profileId);
        //Añadir el repositorio de perfil y igualar el valor de la busqueda
        await projectRepository.AddAsync(project);
        await unitOfWork.CompleteAsync();
        return project;*/
    }
}