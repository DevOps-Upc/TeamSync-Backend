using TeamSync.API.ManagerProject.Domain.Model.Aggregates;


namespace TeamSync.API.ManagerProject.Domain.Model.Entities;

public class Comment
{
    public Comment(){}

    public Comment(string _content,int _profileId,Project _projectId)
    {
        content = _content;
        profileId = _profileId;
        project = _projectId;
        ProjectId = _projectId.Id;
    }
    
    public int Id { get; }
    public string content { get; }
    public int profileId { get; }
    public Project project { get; }
    
    public int ProjectId { get; set; }
}