namespace TeamSync.API.RequestExpert.Domain.Model.Entities;

public class Request
{
    public Request(){}
    
    public int Id { get; }
    public bool state { get; private set; }
}