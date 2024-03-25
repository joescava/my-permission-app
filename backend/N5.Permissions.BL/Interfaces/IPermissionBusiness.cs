using Azure;
using N5.Permissions.BL.Models;
using N5.Permissions.DAL.Entities;

namespace N5.Permissions.BL.Interfaces;
public interface IPermissionBusiness
{
    Task<ApiResponse<PermissionDto>> RequestPermissionAsync(PermissionDto permission);
    Task<ApiResponse<PermissionDto>> ModifyPermissionAsync(int id, PermissionDto permission);
    Task<ApiResponse<IEnumerable<PermissionDto>>> GetEmployeesAsync(); 
    Task<ApiResponse<IEnumerable<PermissionType>>> GetPermissionsAsync(); 
}
