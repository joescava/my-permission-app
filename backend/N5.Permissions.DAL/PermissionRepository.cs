using Microsoft.EntityFrameworkCore;
using N5.Permissions.DAL.Context;
using N5.Permissions.DAL.Entities;
using N5.Permissions.DAL.Interfaces;

namespace N5.Permissions.DAL;
public class PermissionRepository : IPermissionRepository
{
    private readonly PermissionsContext _context;

    public PermissionRepository(PermissionsContext context)
    {
        _context = context;
    }

    public async Task<Permission> AddAsync(Permission permission)
    {
        await _context.Permissions.AddAsync(permission);
        await _context.SaveChangesAsync();
        return permission;
    }

    public async Task<Permission> UpdateAsync(Permission permission)
    {
        _context.Permissions.Update(permission);
        await _context.SaveChangesAsync();
        return permission;
    }

    public async Task<Permission> GetByIdAsync(int id)
    {
        return await _context.Permissions.FindAsync(id);
    }

    public async Task<IEnumerable<Permission>> GetAllAsync()
    {
        return await _context.Permissions
                        .Include(p => p.PermissionType)
                        .ToListAsync();
    }

    public async Task<IEnumerable<PermissionType>> GetAllPermissionAsync()
    {
        return await _context.PermissionTypes.ToListAsync();
    }
}

