using TeamSync.API.ManagerProject.Domain.Model.Entities;

namespace TeamSync.API.ManagerProject.Domain.Model.Aggregates;

public class Project 
{
    public Project(string name, byte[] picture, int profileId)
    {
        Name = name;
        Picture = picture;
        ProfileId = profileId;
        Files = new List<FileAsset>();
    }
    
    public int Id { get; }
    public string Name { get; private set; }
    public byte[] Picture { get; private set; }
    public int ProfileId { get; private set; }
    
    public Project project { get;  }
    public ICollection<FileAsset> Files { get; private set;  } 
    
    public ICollection<Comment> Comments { get; private set; }
    
}