import { useCallback } from "react";
import api from "../api/axios";

export const usePermissionsApi = () => {
  const fetchEmployees = useCallback(async () => {
    try {
      const response = await api.get("/permissions/GetEmployees");
      return response.data.data;
    } catch (error) {
      console.error("Error fetching employees:", error);
      alert(
        "Hubo un problema al obtener la lista de empleados. Por favor, intenta de nuevo."
      );
    }
  }, []);

  const fetchPermission = useCallback(async () => {
    try {
      const response = await api.get("/permissions");
      return response.data.data;
    } catch (error) {
      console.error("Error fetching permissions:", error);
      alert(
        "Hubo un problema al obtener los permisos. Por favor, intenta de nuevo."
      );
    }
  }, []);

  const addPermission = async (formData) => {
    try {
      await api.post("/permissions", formData);
    } catch (error) {
      console.error("Error adding permission:", error);
      alert(
        "Hubo un problema al agregar el permiso. Por favor, verifica la información e intenta de nuevo."
      );
    }
  };

  const updatePermission = async (formData) => {
    try {
      await api.put(`/permissions/${formData.id}`, formData);
    } catch (error) {
      console.error("Error updating permission:", error);
      alert(
        "Hubo un problema al actualizar el permiso. Por favor, verifica la información e intenta de nuevo."
      );
    }
  };

  return { fetchEmployees, fetchPermission, addPermission, updatePermission };
};
