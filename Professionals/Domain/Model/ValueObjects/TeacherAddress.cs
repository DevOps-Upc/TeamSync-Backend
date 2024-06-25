namespace professionals_back_wa.Professionals.Domain.Model.ValueObjects;

public class TeacherAddress
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public TeacherAddress(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
}