import React from "react";
import { List, ListItem, ListItemText, Divider, Button } from "@mui/material";

export const PermissionsList = ({ permissions, handleEditClick }) => {
  return (
    <List>
      {permissions.map((permission, index) => (
        <React.Fragment key={permission.id}>
          <ListItem alignItems="flex-start">
            <ListItemText
              primary={`${permission.nombreEmpleado} ${permission.apellidoEmpleado}`}
              secondary={`Tipo de Permiso: ${
                permission.tipoPermisoDescripcion
              } - Fecha: ${new Date(
                permission.fechaPermiso
              ).toLocaleDateString()}`}
            />
            <Button onClick={() => handleEditClick(permission)} color="primary">
              Editar
            </Button>
          </ListItem>
          {index < permissions.length - 1 && (
            <Divider variant="inset" component="li" />
          )}
        </React.Fragment>
      ))}
    </List>
  );
};
