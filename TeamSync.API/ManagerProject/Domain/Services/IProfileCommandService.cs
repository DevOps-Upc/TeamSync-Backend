using TeamSync.API.ManagerProject.Domain.Model.Aggregates;
using TeamSync.API.ManagerProject.Domain.Model.Commands;
using TeamSync.API.Profile.Domain.Model.Aggregates;
using TeamSync.API.Profile.Domain.Model.Commands;

namespace TeamSync.API.ManagerProject.Domain.Services;

public interface IProfileCommandService
{
    Task<profile?> Handle(CreateProfileCommand command);
    Task<profile?> Handle(DeleteProfileByIdCommand command);
}