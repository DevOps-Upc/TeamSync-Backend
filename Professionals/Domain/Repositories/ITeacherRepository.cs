using professionals_back_wa.Professionals.Domain.Model.Aggregates;

namespace professionals_back_wa.Professionals.Domain.Repositories;

public interface ITeacherRepository
{
    Task AddAsync(Teacher teacher);
    // Other methods...
}