using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Commands;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IProfileCommandService
{
    Task<profile?> Handle(CreateProfileCommand command);
    Task<profile?> Handle(DeleteProfileByIdCommand command);
}