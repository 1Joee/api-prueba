# API Práctica - C# .NET

Este repositorio contiene una Web API RESTful desarrollada en .NET utilizando una arquitectura en capas con el patrón DAO (Data Access Object) y datos mockeados en memoria (`MockDatabase`) para las entidades y Entity Framework Core para los usuarios.

---

## Estructura de la Solución

El proyecto está organizado en tres bibliotecas de clases y proyectos principales:

1. **`entity_library`**: Contiene las entidades base del sistema (`Player`, `Trainer`, `Team`, `Activity`, `TypeActivity`, `Student`, `Course`, `User`).
2. **`dao_library`**: Define las clases DAO (`PlayerDAO`, `TeamDAO`, etc.) para cada entidad, con datos mockeados en `MockDatabase`.
3. **`api_prueba`**: Proyecto ASP.NET Core Web API que expone los controladores (`Controllers`) con endpoints para operaciones CRUD completas.

---

## Endpoints Disponibles

Cada entidad expone el CRUD estándar y responde con los códigos HTTP correspondientes:

* **GET** `/api/[controlador]` - Obtener todos los registros (`200`).
* **GET** `/api/[controlador]/{id}` - Obtener un registro por ID (`200`, o `404` si no existe).
* **POST** `/api/[controlador]` - Crear un nuevo registro (`201`, o `400` si los datos no son válidos).
* **PUT** `/api/[controlador]/{id}` - Actualizar un registro existente (`200`, `400` o `404`).
* **DELETE** `/api/[controlador]/{id}` - Eliminar un registro por ID (`204`, o `404` si no existe).

### Controladores
* `PlayerController`
* `TrainerController`
* `TeamController`
* `StudentController`
* `CourseController`

### Usuarios y login (`/User`)
* **GET** `/User` y **GET** `/User/{id}` - Consultar usuarios.
* **POST** `/User` - Registrar un usuario (contraseña con hash BCrypt; `400` si el email ya existe).
* **POST** `/User/login` - Iniciar sesión. Devuelve un token JWT (`401` si las credenciales son incorrectas).

---

## Cómo Ejecutar el Proyecto

1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/1Joee/api-prueba.git](https://github.com/1Joee/api-prueba.git)