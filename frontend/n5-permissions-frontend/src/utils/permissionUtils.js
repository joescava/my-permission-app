export const extractUniquePermissionTypes = (permissions) => {
  const uniqueTypes = new Map();
  permissions.forEach((p) => {
    uniqueTypes.set(p.id, p.description);
  });
  return Array.from(uniqueTypes).map(([id, descripcion]) => ({
    id,
    descripcion,
  }));
};

export const findDescripcionById = (tiposDePermiso, id) => {
  return tiposDePermiso.find((tipo) => tipo.id === id)?.descripcion || "";
};
