# N5 User Permissions Web API

Este proyecto implementa una Web API para registrar permisos de usuarios para la empresa N5. La API permite la creación, modificación y obtención de permisos de usuario, integrándose con SQL Server para la persistencia de datos y Elasticsearch para la indexación de registros. Además, utiliza Apache Kafka para la mensajería de operaciones.

## Características

- API en ASP.NET Core que persiste datos en SQL Server.
- Uso de Entity Framework para el mapeo ORM.
- Tres servicios principales: "Request Permission", "Modify Permission" y "Get Permissions".
- Integración con Elasticsearch para la indexación de permisos.
- Creación de un tema en Kafka para registrar operaciones con un DTO específico.
- Aplicación de patrones de diseño como Repository, Unit of Work y, opcionalmente, CQRS.
- Pruebas unitarias y de integración para los servicios de la API.
- Frontend en ReactJS con Axios para la conexión con el backend.
- Componentes visuales de Material-UI.

## Estructura del Proyecto

- `backend/`: Contiene la solución de la API de .NET, incluyendo las capas de negocio (BL), acceso a datos (DAL), y la API.
- `frontend/`: Incluye la aplicación de React para la interfaz de usuario.
- `database/`: Almacena scripts SQL para la creación de las tablas `Permissions` y `PermissionTypes`.

