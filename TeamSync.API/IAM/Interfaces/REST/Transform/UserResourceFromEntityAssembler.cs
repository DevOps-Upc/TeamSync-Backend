using TeamSync.API.IAM.Domain.Model.Aggregates;
using TeamSync.API.IAM.Interfaces.REST.Resources;

namespace TeamSync.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}