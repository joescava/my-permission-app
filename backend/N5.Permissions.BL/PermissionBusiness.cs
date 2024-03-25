using N5.Permissions.BL.Interfaces;
using N5.Permissions.BL.Messaging;
using N5.Permissions.BL.Models;
using N5.Permissions.DAL.Entities;
using N5.Permissions.DAL.Interfaces;

namespace N5.Permissions.BL;
public class PermissionBusiness: IPermissionBusiness
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IElasticsearchService _elasticsearchService;
    private readonly IKafkaProducerService _kafkaProducerService;
    public PermissionBusiness(IPermissionRepository permissionRepository, IElasticsearchService elasticsearchService, IKafkaProducerService kafkaProducerService)
    {
        _permissionRepository = permissionRepository;
        _elasticsearchService = elasticsearchService;
        _kafkaProducerService = kafkaProducerService;
    }
    public async Task<ApiResponse<PermissionDto>> RequestPermissionAsync(PermissionDto permissionDto)
    {
        var permission = new Permission
        {
            NombreEmpleado = permissionDto.NombreEmpleado,
            ApellidoEmpleado = permissionDto.ApellidoEmpleado,
            TipoPermiso = permissionDto.TipoPermiso,
            FechaPermiso = permissionDto.FechaPermiso
        };

        // Add to database
        var addedPermission = await _permissionRepository.AddAsync(permission);

        // Index in Elasticsearch
        await _elasticsearchService.IndexPermissionAsync(permissionDto);

        // Map Entity back to DTO
        var resultDto = new PermissionDto
        {
            Id = addedPermission.Id,
            NombreEmpleado = addedPermission.NombreEmpleado,
            ApellidoEmpleado = addedPermission.ApellidoEmpleado,
            TipoPermiso = addedPermission.TipoPermiso,
            FechaPermiso = addedPermission.FechaPermiso
        };

        await _kafkaProducerService.ProduceMessageAsync("permissions_operations", "request", permissionDto);
        return new ApiResponse<PermissionDto>(resultDto);
    }

    public async Task<ApiResponse<PermissionDto>> ModifyPermissionAsync(int id, PermissionDto permissionDto)
    {
        // Find the existing entity
        var permission = await _permissionRepository.GetByIdAsync(id);
        if (permission == null)
        {
            return null;
        }

        // Update the entity
        permission.NombreEmpleado = permissionDto.NombreEmpleado;
        permission.ApellidoEmpleado = permissionDto.ApellidoEmpleado;
        permission.TipoPermiso = permissionDto.TipoPermiso;
        permission.FechaPermiso = permissionDto.FechaPermiso;

        // Save changes to the database
        var updatedPermission = await _permissionRepository.UpdateAsync(permission);
        // Index in Elasticsearch
        await _elasticsearchService.IndexPermissionAsync(permissionDto);

        // Map Entity back to DTO
        var resultDto = new PermissionDto
        {
            Id = updatedPermission.Id,
            NombreEmpleado = updatedPermission.NombreEmpleado,
            ApellidoEmpleado = updatedPermission.ApellidoEmpleado,
            TipoPermiso = updatedPermission.TipoPermiso,
            FechaPermiso = updatedPermission.FechaPermiso
        };

        await _kafkaProducerService.ProduceMessageAsync("permissions_operations", "modify", permissionDto);

        return new ApiResponse<PermissionDto>(resultDto);
    }

    public async Task<ApiResponse<IEnumerable<PermissionType>>> GetPermissionsAsync()
    {
        // Retrieve all permissions from database
        var permissions = await _permissionRepository.GetAllPermissionAsync();
        
        return new ApiResponse<IEnumerable<PermissionType>>(permissions);
    }

    public async Task<ApiResponse<IEnumerable<PermissionDto>>> GetEmployeesAsync()
    {
        // Retrieve all permissions from database
        var permissions = await _permissionRepository.GetAllAsync();
        // Map Entities to DTOs
        var dtoList = permissions.Select(permission => new PermissionDto
        {
            Id = permission.Id,
            NombreEmpleado = permission.NombreEmpleado,
            ApellidoEmpleado = permission.ApellidoEmpleado,
            TipoPermiso = permission.TipoPermiso,
            TipoPermisoDescripcion = permission.PermissionType.Description,
            FechaPermiso = permission.FechaPermiso
        });

        return new ApiResponse<IEnumerable<PermissionDto>>(dtoList);
    }
}
