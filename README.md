# Aplicación de Gestión de Productos con .NET y Svelte

Este proyecto es un ejemplo educativo que muestra cómo crear una aplicación web completa utilizando .NET para el backend y Svelte para el frontend, implementando patrones de diseño modernos y buenas prácticas de desarrollo.

## Descripción del Proyecto

La aplicación permite gestionar un catálogo de productos con operaciones CRUD (Crear, Leer, Actualizar, Eliminar) a través de diferentes interfaces:

- **API REST**: Ofrece endpoints para manipular productos a través de HTTP
- **Backoffice (MVC)**: Interfaz administrativa basada en ASP.NET MVC
- **Frontoffice (Svelte)**: Interfaz de usuario moderna construida con SvelteKit

## Arquitectura del Proyecto

El proyecto sigue una arquitectura en capas con los siguientes componentes:

```
- Products.sln                 # Solución principal
- Products.Common/             # DTOs, excepciones y tipos compartidos
- Products.Business/           # Lógica de negocio, servicios y repositorios
- Products.API/                # API REST
- Products.Backoffice/         # Aplicación MVC para administración
- Products.Frontoffice/        # Frontend con Svelte
```

### Patrón de Arquitectura

- **Diseño por Capas**: Separación clara de responsabilidades entre capas
- **Patrón Repositorio**: Abstracción del acceso a datos
- **Inyección de Dependencias**: Acoplamiento débil entre componentes
- **MVC (Model-View-Controller)**: Para la aplicación Backoffice
- **REST**: Para la API de servicios

## Tecnologías Utilizadas

### Backend

- **.NET 9**: Framework base para el desarrollo
- **ASP.NET Core**: Para la API REST y aplicación MVC
- **Entity Framework Core**: ORM para acceso a datos
- **AutoMapper**: Para mapeo entre objetos de dominio y DTOs
- **Newtonsoft.Json**: Para serialización/deserialización JSON
- **In-Memory Database**: Para almacenamiento de datos (en este ejemplo educativo)

### Frontend

- **SvelteKit**: Framework para la creación de la interfaz de usuario
- **TypeScript**: Para tipado estático en el frontend
- **Axios**: Para comunicación HTTP con la API
- **Zod**: Para validación de datos en el cliente

### DevOps

- **Docker**: Para contenerización de la aplicación
- **Fly.io**: Ejemplo de despliegue en la nube

## Patrones de Diseño Implementados

- **DTO (Data Transfer Objects)**: Para transferencia de datos entre capas
- **Repositorio**: Para abstracción del acceso a datos
- **Servicios**: Para encapsular la lógica de negocio
- **Middleware**: Para manejo centralizado de excepciones
- **CORS**: Configuración para permitir solicitudes cross-origin
- **Enumeraciones**: Para tipos de datos con valores predefinidos (Colores)

## Configuración del Entorno de Desarrollo

### Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js](https://nodejs.org/) (v20.x o superior)

### Pasos para Ejecutar el Proyecto

1. **Clonar el Repositorio**:

   ```
   git clone <url-del-repositorio>
   cd Products
   ```

2. **Restaurar Paquetes NuGet**:

   ```
   dotnet restore
   ```

3. **Ejecutar la API REST**:

   ```
   dotnet run --project Products.API
   ```

   La API estará disponible en: https://localhost:7234 (o http://localhost:5192)

4. **Ejecutar la Aplicación Backoffice (MVC)**:

   ```
   dotnet run --project Products.Backoffice
   ```

   La aplicación MVC estará disponible en: https://localhost:7103

5. **Ejecutar la Aplicación Frontoffice (Svelte)**:
   ```
   cd Products.Frontoffice
   npm install
   npm run dev
   ```
   La aplicación Svelte estará disponible en: http://localhost:5173

## Estructura del Código

### Products.Common

Contiene elementos compartidos:

- **Dtos/**: Objetos de transferencia de datos
- **Types/**: Enumeraciones y tipos personalizados
- **Exceptions/**: Excepciones personalizadas

### Products.Business

Contiene la lógica de negocio:

- **Domain/**: Entidades de dominio
- **Service/**: Servicios que implementan la lógica de negocio
- **Repository/**: Acceso a datos
- **Persistence/**: Contexto de Entity Framework
- **AutoMapperProfiles/**: Configuración de mapeo entre entidades y DTOs

### Products.API

API REST:

- **Controllers/**: Endpoints de la API
- **Middlewares/**: Configuración de middleware para manejo de excepciones

### Products.Backoffice

Aplicación MVC:

- **Controllers/**: Controladores MVC
- **Views/**: Vistas Razor
- **Models/**: ViewModels específicos para la UI

### Products.Frontoffice

Aplicación Svelte:

- **src/routes/**: Páginas y componentes
- **src/lib/**: Utilidades, stores y lógica compartida
- **src/lib/api.ts**: Cliente de la API REST

## Aspectos Educativos del Proyecto

Este proyecto sirve como referencia para aprender sobre:

1. **Arquitectura en Capas**: Separación de responsabilidades
2. **API REST**: Principios y buenas prácticas
3. **Inyección de Dependencias**: Configuración y uso en .NET
4. **Entity Framework Core**: Configuración básica y seeds
5. **Manejo de Excepciones**: Middleware centralizado
6. **Validación de Datos**: Tanto en backend como frontend
7. **Frontend Moderno**: Integración con frameworks modernos (Svelte)
8. **Serialización/Deserialización**: Conversión entre objetos y JSON
9. **Enumeraciones**: Uso en C# y TypeScript
10. **Patrones de Repositorio y Servicio**: Implementación práctica

## Despliegue

El proyecto incluye un Dockerfile para contenerización y puede ser desplegado en servicios como Fly.io:

```
fly deploy
```

Un ejemplo de despliegue está disponible en: https://tsi-products.fly.dev/

## Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

**Nota**: Este proyecto es principalmente educativo y está diseñado para demostrar conceptos y patrones en un entorno simplificado. Algunas prácticas pueden necesitar ser adaptadas para aplicaciones de producción a gran escala.
