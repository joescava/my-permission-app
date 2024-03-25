CREATE TABLE Permissions (
	Id int IDENTITY(1,1) NOT NULL,
	NombreEmpleado nvarchar(255) NOT NULL,
	ApellidoEmpleado nvarchar(255) NOT NULL,
	TipoPermiso int NOT NULL,
	FechaPermiso date NOT NULL,
	CONSTRAINT PK_Permissions PRIMARY KEY (Id),
	CONSTRAINT FK_Permissions_PermissionTypes FOREIGN KEY (TipoPermiso) REFERENCES PermissionTypes(Id)
);
