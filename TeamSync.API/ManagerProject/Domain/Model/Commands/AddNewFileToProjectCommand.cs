namespace TeamSync.API.ManagerProject.Domain.Model.Commands;

public record AddNewFileToProjectCommand(byte[] datafile,string _name,string _type,int _projectId);