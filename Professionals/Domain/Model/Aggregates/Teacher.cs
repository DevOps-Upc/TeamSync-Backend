using professionals_back_wa.Professionals.Domain.Model.Commands;
using professionals_back_wa.Professionals.Domain.Model.ValueObjects;

namespace professionals_back_wa.Professionals.Domain.Model.Aggregates;

public partial class Teacher
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public TeacherAdress Adress { get; set; }
    public string EspecializationArea { get; set; }

    protected Teacher()
    {
        this.Name = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Adress = new TeacherAdress();
        this.EspecializationArea = string.Empty;
    }

    public Teacher(CreateTeacherCommand command)
    {
        this.Name = command.Name;
        this.LastName = command.LastName;
        this.Email = command.Email;
        this.Adress = command.Adress;
        this.EspecializationArea = command.EspecializationArea;
    }
}