# API Práctica - C# .NET

Este repositorio contiene una Web API RESTful desarrollada en .NET utilizando una arquitectura en capas con el patrón DAO (Data Access Object) y persisatencia estática en memoria.

---

## Estructura de la Solución

El proyecto está organizado en tres bibliotecas de clases y proyectos principales:

1. **`entity_library`**: Contiene las entidades base del sistema (`Player`, `Trainer`, `Team`, `Activity`, `TypeActivity`, `Student`, `Course`).
2. **`dao_library`**: Define la interfaz genérica `IDao<T>` y las implementaciones DAO para cada entidad con datos mockeados en memoria.
3. **`api_prueba`**: Proyecto ASP.NET Core Web API que expone los controladores (`Controllers`) con endpoints para operaciones CRUD completas.

---

## Endpoints Disponibles

Cada entidad expone las operaciones estándar de HTTP:

* **GET** `/api/[controlador]` - Obtener todos los registros.
* **GET** `/api/[controlador]/{id}` - Obtener un registro por ID.
* **POST** `/api/[controlador]` - Crear un nuevo registro.
* **PUT** `/api/[controlador]` - Actualizar un registro existente.
* **DELETE** `/api/[controlador]/{id}` - Eliminar un registro por ID.

### Controladores
* `PlayerController`
* `TrainerController`
* `TeamController`
* `ActivityController`
* `TypeActivityController`
* `StudentController`
* `CourseController`

---

## Cómo Ejecutar el Proyecto

1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/1Joee/api-prueba.git](https://github.com/1Joee/api-prueba.git)