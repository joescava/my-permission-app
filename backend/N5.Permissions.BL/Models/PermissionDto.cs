namespace N5.Permissions.BL.Models;
public class PermissionDto
{
    public int Id { get; set; }
    public string NombreEmpleado { get; set; }
    public string ApellidoEmpleado { get; set; }
    public int TipoPermiso { get; set; }
    public string TipoPermisoDescripcion { get; set; }
    
    public DateTime FechaPermiso { get; set; }
}
