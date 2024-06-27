using TeamSync.API.Profile.Domain.Model.ValueObjects;

namespace TeamSync.API.Profile.Domain.Model.Aggregates;

public class profile 
{
    public profile(){}
    public profile(string firstname,string lastname, string address, byte[] picture, int roleid, string emailAddress, string membership)
    {
        //id ya esta incluido
        FirstName = firstname;
        LastName = lastname;//Nombre persona
        Address = address; 
        Picture = picture; // foto de perfil
        
        RoleId = (ERole)roleid;
        EmailAddress = emailAddress;
        Membership = membership;
    }
    
    public int Id { get; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public byte[] Picture { get; private set; }
    
    public ERole RoleId { get; private set; }
    public string EmailAddress { get; private set; }
    public string Membership { get; private set; }
    
    public profile Profile { get;  }
    
}