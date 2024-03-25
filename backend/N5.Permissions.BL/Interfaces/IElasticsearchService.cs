using N5.Permissions.BL.Models;

namespace N5.Permissions.BL.Interfaces;
public interface IElasticsearchService
{
    Task IndexPermissionAsync(PermissionDto permissionDto);
}
