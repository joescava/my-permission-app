using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Permissions.DAL.Entities;
public class Permission
{
    public int Id { get; set; }
    public string NombreEmpleado { get; set; }
    public string ApellidoEmpleado { get; set; }
    public int TipoPermiso { get; set; }
    public DateTime FechaPermiso { get; set; }

    // Relación de EF Core para PermissionType
    public PermissionType PermissionType { get; set; }
}
