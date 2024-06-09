using TeamSync.API.ManagerProject.Domain.Model.Entities;
using TeamSync.API.ManagerProject.Interface.REST.Resources;

namespace TeamSync.API.ManagerProject.Interface.REST.Transform;

public static class FileAssetResourceFromEntityAssembler
{
    public static FileAssetResource ToResourceFromEntity(FileAsset fileAsset)
    {
        return new FileAssetResource(
            fileAsset.Id, 
            fileAsset.Datafile, 
            fileAsset.Name, 
            fileAsset.Type,
            fileAsset.ProjectId);
    }
}