namespace TeamSync.API.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, string Token, int ProfileId);