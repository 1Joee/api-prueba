# API Práctica - C# .NET

Este repositorio contiene una Web API RESTful desarrollada en .NET utilizando una arquitectura en capas con el patrón DAO (Data Access Object) y datos mockeados en memoria (`MockDatabase`) para las entidades y Entity Framework Core para los usuarios.

---

## Estructura de la Solución

El proyecto está organizado en tres bibliotecas de clases y proyectos principales:

1. **`entity_library`**: Contiene las entidades base del sistema (`Player`, `Trainer`, `Team`, `Activity`, `TypeActivity`, `Student`, `Course`, `User`).
2. **`dao_library`**: Define las clases DAO (`PlayerDAO`, `TeamDAO`, etc.) para cada entidad, con datos mockeados en `MockDatabase`.
3. **`api_prueba`**: Proyecto ASP.NET Core Web API que expone los controladores (`Controllers`) con endpoints para operaciones CRUD completas.
4. **`frontend`**: Aplicación Angular que consume la API (login, dashboard y formulario de usuarios).

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

## Frontend (Angular)

Aplicación Angular con componentes standalone, servicios, rutas protegidas e interceptor JWT.

### Rutas

| Ruta | Pantalla | Protegida |
|---|---|---|
| `/login` | Login con formulario reactivo | No |
| `/dashboard` | Dashboard con tarjetas de resumen y últimos usuarios | Sí |
| `/users` | Listado de usuarios | Sí |
| `/users/new` | Formulario de alta de usuario | Sí |

Las rutas protegidas usan `authGuard`: si no hay token guardado, redirige a `/login`.

### Dashboard
Muestra el total de usuarios, la cantidad de administradores y de usuarios comunes, y los últimos 5 registrados. Incluye navegación y cierre de sesión.

### Formularios
* **Login**: formulario reactivo con `Validators.required` y `Validators.email`.
* **Alta de usuario**: formulario reactivo con `FormBuilder`, grupo anidado `credentials` (email, contraseña y confirmación), validaciones por campo (nombre, edad entre 1 y 100, DNI de 7 u 8 dígitos, email, contraseña de mínimo 8 caracteres) y un validador propio (`passwordMatchValidator`) que verifica que las contraseñas coincidan.

---

## Cómo Ejecutar el Proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/1Joee/api-prueba.git
   ```
2. Levantar la API (queda escuchando en `http://localhost:5122`):
   ```bash
   cd api_prueba
   dotnet run
   ```
3. En otra terminal, levantar el frontend (queda en `http://localhost:4200`):
   ```bash
   cd frontend
   npm install
   ng serve
   ```
