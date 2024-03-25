import { useState, useEffect, useCallback } from "react";
import { usePermissionsApi } from "../hooks/usePermissionsApi";
import {
  findDescripcionById,
  extractUniquePermissionTypes,
} from "../utils/permissionUtils";
import { parseISO } from "date-fns";

export const usePermissionForm = () => {
  // Estado inicial del formulario
  const [formData, setFormData] = useState({
    nombreEmpleado: "",
    apellidoEmpleado: "",
    tipoPermiso: "",
    tipoPermisoDescripcion: "",
    fechaPermiso: null,
  });
  const [permissions, setPermissions] = useState([]);
  const [isEditMode, setIsEditMode] = useState(false);
  const [tiposDePermiso, setTiposDePermiso] = useState([]);

  // Métodos de la API
  const { fetchEmployees, fetchPermission, addPermission, updatePermission } =
    usePermissionsApi();

  // Función para manejar los cambios de los inputs del formulario
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
      ...(name === "tipoPermiso" && {
        tipoPermisoDescripcion: findDescripcionById(tiposDePermiso, value),
      }),
    }));
  };

  // Función para manejar el cambio de fecha
  const handleDateChange = (date) => {
    setFormData((prev) => ({ ...prev, fechaPermiso: date }));
  };

  // Función para manejar la presentación del formulario
  const handleSubmit = async (e) => {
    e.preventDefault();
    const method = isEditMode ? updatePermission : addPermission;
    await method(formData);
    resetForm();
    refreshPermissions();
  };

  // Función para resetear el formulario
  const resetForm = () => {
    setFormData({
      nombreEmpleado: "",
      apellidoEmpleado: "",
      tipoPermiso: "",
      tipoPermisoDescripcion: "",
      fechaPermiso: null,
    });
  };

  // Función para cargar los permisos y tipos de permiso
  const refreshPermissions = useCallback(async () => {
    const employeesData = await fetchEmployees();
    const permissionData = await fetchPermission();
    setPermissions(
      employeesData.map((permission) => ({
        ...permission,
        fechaPermiso: parseISO(permission.fechaPermiso),
      }))
    );
    setTiposDePermiso(extractUniquePermissionTypes(permissionData));
  }, [fetchEmployees, fetchPermission]);

  // Función para manejar la edición de un permiso existente
  const handleEditClick = (permission) => {
    setFormData(permission);
    setIsEditMode(true);
  };

  // Función para cancelar la edición
  const handleCancelEdit = () => {
    resetForm();
    setIsEditMode(false);
  };

  // Inicializar los permisos en la carga del componente
  useEffect(() => {
    refreshPermissions();
  }, [refreshPermissions]);

  return {
    formData,
    permissions,
    isEditMode,
    tiposDePermiso,
    handleChange,
    handleDateChange,
    handleSubmit,
    handleEditClick,
    handleCancelEdit,
    refreshPermissions,
  };
};
