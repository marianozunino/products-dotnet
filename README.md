## Ejemplo de Aplicación .NET con MVC y API REST 🚀

A continuación, encontrarás instrucciones detalladas sobre cómo configurar y ejecutar este proyecto .NET. El proyecto consta de varios componentes que incluyen lógica de negocio, aplicaciones web y una API REST para administrar productos.

## Estructura del Proyecto

La estructura del proyecto es la siguiente:

```
- global.json
- Products.sln
- Products.Common/
- Products.Business/
- Products.Backoffice/
- Products.API/
- Products.Frontoffice/
```

- **global.json**: Archivo de configuración global para la versión de .NET SDK.
- **Products.sln**: Archivo de solución principal del proyecto.
- **Products.Common**: Contiene DTOs y excepciones compartidas.
- **Products.Business**: Contiene la lógica de negocio del proyecto, incluidos servicios y repositorios.
- **Products.Backoffice**: Aplicación MVC para el backoffice de administración.
- **Products.API**: Aplicación MVC que expone una API REST para administrar productos.
- **Products.Frontoffice**: Proyecto Svelte que muestra cómo consumir la API REST.

## Pasos para Iniciar

A continuación, se describen los pasos para configurar y ejecutar el proyecto:

1. **Requisitos Previos**:
   - Asegúrate de tener instalado el SDK de .NET en tu máquina.
   - Asegúrate de tener Node.js instalado para ejecutar el proyecto Svelte.

2. **Clonar el Repositorio**:
   Clona el repositorio del proyecto desde su ubicación.

4. **Restaurar Paquetes NuGet**:
   Abre una terminal en la ubicación de la solución (`Products.sln`) y ejecuta el comando:
   ```
   dotnet restore
   ```

5. **Ejecutar Aplicaciones MVC**:
   - Para el proyecto Backoffice, navega a la carpeta `Products.Backoffice` en la terminal y ejecuta:
     ```bash
     dotnet run
     ```
     o desde la raiz del proyecto:
     ```bash
     dotnet run --project Products.Backoffice
     ```
   - Para el proyecto API, navega a la carpeta `Products.API` en la terminal y ejecuta:
     ```
     dotnet run
     ```
     o desde la raiz del proyecto:
     ```bash
     dotnet run --project Products.API
     ```

6. **Ejecutar Proyecto Svelte**:
   - Navega a la carpeta `Products.Frontoffice` en la terminal.
   - Instala las dependencias ejecutando `npm install`.
   - Luego, inicia la aplicación con `npm run dev`.

7. **¡Listo!**:
   Ahora puedes acceder a las aplicaciones MVC desde tu navegador y probar la API REST.
  Además, el proyecto Svelte te mostrará cómo consumir la API desde un frontend.

## Migraciones (branch `migrations`)

Inrtalar `dotnet ef` ([how-to](httpr://learn.microsoft.com/en-us/ef/core/cli/dotnet)) para poder gestionar las migraciones.

- `dotnet ef database update`: Actualiza la base de datos
- `dotnet ef migrations add <nombre de la migración>`: Crea una nueva migración
- `dotnet ef migrations remove <nombre de la migración>`: Elimina una migración
- `dotnet ef migrations list`: Lista las migraciones

```bash
dotnet ef database update
dotnet ef migrations add <nombre de la migración>
dotnet ef migrations remove <nombre de la migración>
dotnet ef migrations list
```

**Nota**: Como este proyecto utiliza la base de datos SQLite, es imporante que se respete la ubicación de la base de datos.
Es por ello que los comandos deben se ejecutados desde la raiz del proyecto haciendo uso del flag `--project`.

```bash
dotnet ef database update --project Products.Business
dotnet ef migrations add <nombre de la migración> --project Products.Business
dotnet ef migrations remove <nombre de la migración> --project Products.Business
dotnet ef migrations list --project Products.Business
```

## Deploy en Fly.io

Se ha realizado un deploy de la aplicación MVC en Fly.io. Puedes acceder a ella desde el siguiente enlace:
https://tsi-products.fly.dev/


