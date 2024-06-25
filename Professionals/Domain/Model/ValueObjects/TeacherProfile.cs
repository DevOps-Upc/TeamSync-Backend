namespace professionals_back_wa.Professionals.Domain.Model.ValueObjects;

public class TeacherProfile
{
    public string Name { get; }
    public string LastName { get; }
    public string Email { get; }
    public string EspecializationArea { get; }
    
public TeacherProfile(string name, string lastName, string email, string especializationArea)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        EspecializationArea = especializationArea;
    }
}