using professionals_back_wa.Professionals.Domain.Model.Commands;
using professionals_back_wa.Professionals.Domain.Model.ValueObjects;

namespace professionals_back_wa.Professionals.Domain.Model.Aggregates;

public partial class Teacher
{
    public TeacherProfile TeacherProfile { get; set; }
    public TeacherAddress TeacherAddress { get; set; }
    
    public Teacher(CreateTeacherCommand command)
    {
        this.TeacherProfile = new TeacherProfile(command.Name, command.LastName, command.Email, command.EspecializationArea);
        this.TeacherAddress = new TeacherAddress(command.Adress, "", "");
    }
}