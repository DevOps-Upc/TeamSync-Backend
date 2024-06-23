namespace professionals_back_wa.Professionals.Domain.Model.ValueObjects;

public class TeacherProfile
{
    public TeacherProfile(string name, string lastName, string email, TeacherAdress adress, string especializationArea)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Adress = adress;
        EspecializationArea = especializationArea;
    }

    public string Name { get; }
    public string LastName { get; }
    public string Email { get; }
    public TeacherAdress Adress { get; }
    public string EspecializationArea { get; }
}