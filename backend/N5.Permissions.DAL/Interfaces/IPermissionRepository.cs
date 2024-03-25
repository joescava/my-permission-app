using N5.Permissions.DAL.Entities;

namespace N5.Permissions.DAL.Interfaces;
public interface IPermissionRepository
{
    Task<Permission> AddAsync(Permission permission);
    Task<Permission> UpdateAsync(Permission permission);
    Task<Permission> GetByIdAsync(int id);
    Task<IEnumerable<Permission>> GetAllAsync();
    Task<IEnumerable<PermissionType>> GetAllPermissionAsync();
}
