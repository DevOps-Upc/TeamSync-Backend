using TeamSync.API.IAM.Domain.Model.Aggregates;
using TeamSync.API.IAM.Interfaces.REST.Resources;

namespace TeamSync.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token,user.ProfileId);
    }
}