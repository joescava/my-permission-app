using Microsoft.AspNetCore.Mvc;
using N5.Permissions.BL.Interfaces;
using N5.Permissions.BL.Messaging;
using N5.Permissions.BL.Models;

namespace N5.Permissions.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionBusiness _permissionBusiness;
    
    public PermissionsController(IPermissionBusiness permissionBusiness)
    {
        _permissionBusiness = permissionBusiness;
    }

    [HttpPost]
    public async Task<ActionResult> RequestPermission(PermissionDto permissionDto)
    {
        var result = await _permissionBusiness.RequestPermissionAsync(permissionDto);
        return result != null ? Ok(result) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ModifyPermission(int id, PermissionDto permissionDto)
    {
        var result = await _permissionBusiness.ModifyPermissionAsync(id, permissionDto);
        return result != null ? Ok(result) : BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> GetPermission()
    {
        var result = await _permissionBusiness.GetPermissionsAsync();
        return Ok(result);
    }

    [HttpGet("GetEmployees")]
    public async Task<ActionResult> GetEmployees()
    {
        var result = await _permissionBusiness.GetEmployeesAsync();
        return Ok(result);
    }

}
