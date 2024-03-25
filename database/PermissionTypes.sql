CREATE TABLE PermissionTypes (
	Id int IDENTITY(1,1) NOT NULL,
	Description nvarchar(255) NOT NULL,
	CONSTRAINT PK_PermissionTypes PRIMARY KEY (Id)
);
