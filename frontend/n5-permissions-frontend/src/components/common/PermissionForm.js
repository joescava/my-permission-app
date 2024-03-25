import React, { useState } from "react";
import { Box, TextField, Button, MenuItem } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";

export const PermissionForm = ({
  formData,
  handleChange,
  handleDateChange,
  handleSubmit,
  isEditMode,
  tiposDePermiso,
  handleCancelEdit,
}) => {
  const [isSubmitting, setIsSubmitting] = useState(false);

  const onSubmit = async (event) => {
    setIsSubmitting(true);
    await handleSubmit(event);
    setIsSubmitting(false);
  };

  return (
    <Box component="form" onSubmit={onSubmit} autoComplete="off">
      <TextField
        fullWidth
        label="Nombre del Empleado"
        name="nombreEmpleado"
        value={formData.nombreEmpleado}
        onChange={handleChange}
        margin="normal"
      />
      <TextField
        fullWidth
        label="Apellido del Empleado"
        name="apellidoEmpleado"
        value={formData.apellidoEmpleado}
        onChange={handleChange}
        margin="normal"
      />
      <DatePicker
        label="Fecha del Permiso"
        value={formData.fechaPermiso}
        onChange={handleDateChange}
        inputFormat="dd/MM/yyyy"
      >
        {({ inputRef, inputProps, InputComponent }) => (
          <Box sx={{ display: "flex", alignItems: "center" }}>
            <InputComponent ref={inputRef} {...inputProps} />
          </Box>
        )}
      </DatePicker>
      <TextField
        fullWidth
        select
        label="Tipo de Permiso"
        name="tipoPermiso"
        value={formData.tipoPermiso}
        onChange={handleChange}
        margin="normal"
      >
        {tiposDePermiso.map((tipo) => (
          <MenuItem key={tipo.id} value={tipo.id}>
            {tipo.descripcion}
          </MenuItem>
        ))}
      </TextField>
      <Box mt={2} display="flex" justifyContent="space-between">
        <Button
          type="submit"
          variant="contained"
          color="primary"
          disabled={isSubmitting}
        >
          {isEditMode ? "Actualizar Permiso" : "Enviar Permiso"}
        </Button>
        {isEditMode && (
          <Button
            onClick={handleCancelEdit}
            variant="outlined"
            disabled={isSubmitting}
          >
            Cancelar Edición
          </Button>
        )}
      </Box>
    </Box>
  );
};
