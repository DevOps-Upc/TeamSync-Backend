using professionals_back_wa.Professionals.Domain.Model.ValueObjects;

namespace professionals_back_wa.Professionals.Domain.Model.Commands;

public record CreateTeacherCommand(
    string Name,
    string LastName,
    string Email,
    TeacherAdress Adress,
    string EspecializationArea
);