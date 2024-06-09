using TeamSync.API.ManagerProject.Domain.Model.Aggregates;

namespace TeamSync.API.ManagerProject.Domain.Model.Entities;

public class FileAsset
{
    public FileAsset()
    {
        
    }
    public FileAsset(byte[] datafile,string _name,string _type,int _projectId)
    {
        Datafile = datafile;
        Name = _name;
        Type = _type;
        ProjectId = _projectId;

    }
    
    public FileAsset(byte[] datafile,string _name,string _type,Project _project)
    {
        Datafile = datafile;
        Name = _name;
        Type = _type;
        project = _project;
        ProjectId = project.Id;

    }
    
    public int Id { get; }
    
    public byte[] Datafile { get; private set; }
    
    public string Name { get; private set; }
    
    public string Type { get; private set;}
    
    public Project project { get; private set;  }
    
    public int ProjectId { get; private set; }
}