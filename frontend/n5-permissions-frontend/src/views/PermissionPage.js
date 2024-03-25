import React from "react";
import { Typography, Grid, Paper } from "@mui/material";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import { PermissionForm } from "../components/common/PermissionForm";
import { PermissionsList } from "../components/common/PermissionsList";
import { usePermissionForm } from "../hooks/usePermissionsForm";

const PermissionPage = () => {
  const {
    formData,
    permissions,
    isEditMode,
    tiposDePermiso,
    handleChange,
    handleDateChange,
    handleSubmit,
    handleEditClick,
    handleCancelEdit,
  } = usePermissionForm();

  return (
    <LocalizationProvider dateAdapter={AdapterDateFns}>
      <Grid container spacing={2} justifyContent="center">
        <Grid item xs={12}>
          <Typography variant="h4" align="center">
            Gestión de Permisos
          </Typography>
        </Grid>
        <Grid item xs={6}>
          <Paper elevation={3} style={{ padding: 16 }}>
            <PermissionForm
              formData={formData}
              handleChange={handleChange}
              handleDateChange={handleDateChange}
              handleSubmit={handleSubmit}
              isEditMode={isEditMode}
              tiposDePermiso={tiposDePermiso}
              handleCancelEdit={handleCancelEdit}
            />
          </Paper>
        </Grid>
        <Grid item xs={6}>
          <Paper
            elevation={3}
            style={{ padding: 16, maxHeight: 400, overflow: "auto" }}
          >
            <Typography variant="h6" gutterBottom>
              Listado de Personas y Permisos
            </Typography>
            <PermissionsList {...{ permissions, handleEditClick }} />
          </Paper>
        </Grid>
      </Grid>
    </LocalizationProvider>
  );
};
export default PermissionPage;
