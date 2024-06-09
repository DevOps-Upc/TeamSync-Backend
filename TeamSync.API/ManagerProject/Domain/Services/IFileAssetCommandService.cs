using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.ManagerProject.Domain.Model.Entities;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IFileAssetCommandService
{
    Task<FileAsset?> Handle(AddNewFileToProjectCommand command);
}