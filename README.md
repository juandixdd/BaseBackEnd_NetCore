Perfecto 🚀
Te voy a dejar un README profesional, claro, estructurado y listo para GitHub, mostrando:

📌 Descripción del proyecto

🏗 Arquitectura

⚙️ Tecnologías usadas

🔐 Autenticación

📦 Endpoints documentados

📄 Ejemplos de request/response

🧠 Paginación

🚀 Cómo ejecutar

🛠 Migraciones automáticas

📘 Buenas prácticas implementadas

Puedes copiarlo directamente como README.md.

📦 BaseBackend API

API REST desarrollada en ASP.NET Core siguiendo principios de Clean Architecture, con autenticación JWT, manejo global de errores, paginación profesional y AutoMapper.

🚀 Características Principales

✅ Clean Architecture
✅ JWT Authentication
✅ Paginación profesional
✅ AutoMapper
✅ Middleware global de excepciones
✅ Migraciones automáticas
✅ Swagger con soporte JWT
✅ Validaciones personalizadas
✅ Separación por módulos

🏗 Arquitectura del Proyecto
BaseBackend
│
├── Api
│   ├── Controllers
│   ├── Middlewares
│
├── Application
│   ├── Services
│   ├── DTOs
│   ├── Common
│       ├── Exceptions
│       ├── Pagination
│       ├── Mappings
│
├── Domain
│   ├── Entities
│   ├── Interfaces
│
├── Infrastructure
│   ├── Persistence
│   ├── Security

🛠 Tecnologías Utilizadas

.NET 8

Entity Framework Core

SQL Server

JWT Bearer Authentication

AutoMapper

Swagger (OpenAPI)

⚙️ Configuración
🔑 JWT (appsettings.json)
"Jwt": {
  "Key": "YOUR_SECRET_KEY",
  "Issuer": "BaseBackend",
  "Audience": "BaseBackendUsers"
}

🗄 Base de Datos

Las migraciones se aplican automáticamente al iniciar la aplicación:

db.Database.Migrate();


No es necesario ejecutar update-database.

🔐 Autenticación

La API usa JWT Bearer.

Después de hacer login, debes enviar el token en el header:

Authorization: Bearer {token}


Swagger ya está configurado para soportar JWT.

📘 Endpoints
🔑 Auth Module

Base URL:

/api/Auth

📝 Register
POST /api/Auth/register

Registra un nuevo usuario.

Request Body
{
  "email": "user@email.com",
  "password": "123456"
}

Responses
Código	Descripción
201	Usuario creado
400	Email inválido / ya existe
400	Password inválido
🔓 Login
POST /api/Auth/login

Autentica un usuario y devuelve un JWT.

Request Body
{
  "email": "user@email.com",
  "password": "123456"
}

Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

Responses
Código	Descripción
200	Login exitoso
401	Credenciales inválidas
400	Datos inválidos
📦 Product Module

Base URL:

/api/Product


🔒 Requiere autenticación.

📄 Get All (Paginado)
GET /api/Product?page=1&pageSize=10
Query Parameters
Parámetro	Tipo	Default	Máximo
page	int	1	—
pageSize	int	10	50
Response
{
  "items": [
    {
      "id": 1,
      "name": "Laptop",
      "price": 1500
    }
  ],
  "page": 1,
  "pageSize": 10,
  "totalCount": 25,
  "totalPages": 3
}

📄 Get By Id
GET /api/Product/{id}
Response
{
  "id": 1,
  "name": "Laptop",
  "price": 1500
}

Errors
Código	Descripción
404	Producto no encontrado
➕ Create Product
POST /api/Product
Request Body
{
  "name": "Mouse",
  "price": 50
}

Response
{
  "message": "Product created successfully"
}

Errors
Código	Descripción
400	Nombre requerido
400	Precio inválido
✏ Update Product
PUT /api/Product/{id}
Request Body
{
  "name": "Mouse Gamer",
  "price": 80
}

Responses
Código	Descripción
204	Actualizado
404	No encontrado
400	Datos inválidos
❌ Delete Product
DELETE /api/Product/{id}
Responses
Código	Descripción
204	Eliminado
404	No encontrado
⚠ Manejo de Errores

Todos los errores son manejados por un middleware global.

Formato estándar:

{
  "success": false,
  "status": 400,
  "error": "Product name is required"
}


Tipos de errores:

ValidationException → 400

UnauthorizedException → 401

NotFoundException → 404

Error inesperado → 500

🧠 Paginación

Implementada usando:

Skip

Take

TotalCount

TotalPages

Optimizada para ejecutarse en SQL, no en memoria.

🗺 AutoMapper

Se usa AutoMapper para:

Mapear Entity → DTO

Mapear DTO → Entity

Reducir código repetitivo

Mejorar mantenibilidad

Profiles ubicados en:

Application/Common/Mappings

🚀 Cómo Ejecutar
dotnet restore
dotnet run


Swagger disponible en:

https://localhost:{port}/swagger

🧪 Flujo Completo de Prueba

Registrar usuario

Hacer login

Copiar token

Autorizar en Swagger

Consumir endpoints protegidos
