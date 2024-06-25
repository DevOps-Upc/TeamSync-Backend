using professionals_back_wa.Professionals.Domain.Model.Aggregates;
using professionals_back_wa.Professionals.Domain.Model.Commands;
using professionals_back_wa.Professionals.Domain.Model.ValueObjects;
using professionals_back_wa.Professionals.Domain.Repositories;
using professionals_back_wa.Professionals.Domain.Services;
using professionals_back_wa.Shared.Domain.Repositories;

namespace professionals_back_wa.Professionals.Application.Internal.CommandServices;

public class TeacherCommandService : ITeacherCommandService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TeacherCommandService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
    {
        _teacherRepository = teacherRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Teacher> Handle(CreateTeacherCommand command)
    {
        var teacherProfile = new TeacherProfile(command.Name, command.LastName, command.Email, command.EspecializationArea);
        var teacherAddress = new TeacherAddress(command.Street, command.City, command.Country);
        var teacher = new Teacher(teacherProfile, teacherAddress);

        await _teacherRepository.AddAsync(teacher);
        await _unitOfWork.CompleteAsync();

        return teacher;
    }
}