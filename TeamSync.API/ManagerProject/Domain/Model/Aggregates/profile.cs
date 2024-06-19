using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace TeamSync.API.ManagerProject.Domain.Model.Aggregates;

public class profile 
{
    public profile(string name, string address, byte[] picture, string company, string role, string emailAddress, string membership)
    {
        //id ya esta incluido
        Name = name; //Nombre persona
        Address = address; 
        Picture = picture; // foto de perfil
        Company = company;
        Role = role;
        EmailAddress = emailAddress;
        Membership = membership;
    }
    
    public int Id { get; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public byte[] Picture { get; private set; }
    public string Company { get; private set; }
    public string Role { get; private set; }
    public string EmailAddress { get; private set; }
    public string Membership { get; private set; }
    
    public profile Profile { get;  }
    
}