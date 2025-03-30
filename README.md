# Proyecto Manantial

## Descripción
Manantial es un proyecto basado en una arquitectura multicapa utilizando .NET para el backend, Angular para el frontend y SQL Server como base de datos. Este proyecto sigue buenas prácticas de desarrollo, incluyendo patrones de diseño como MVC y principios SOLID.

## Tecnologías Utilizadas
- **Backend**: C# con .NET Core
- **Frontend**: Angular
- **Base de datos**: SQL Server
- **ORM**: Entity Framework Core
- **Servicios**: REST API
- **Control de versiones**: Git & GitHub
- **Herramientas adicionales**:
  - Postman (para pruebas de API)
  - Swagger (documentación de API)
  - AutoMapper (mapeo de objetos)
  - Bootstrap (estilizado del frontend)

## Requisitos Previos
- Instalar **Visual Studio Code** o **Visual Studio 2022**
- Instalar **.NET SDK**
- Instalar **Node.js y Angular CLI**
- Instalar **SQL Server**
- Tener una cuenta en **GitHub** y configurar **Git**

## Configuración del Entorno
### Instalación de Herramientas
1. Instalar Postman: [Descargar](https://www.postman.com/downloads/)
2. Instalar Git: [Descargar](https://git-scm.com/downloads)
3. Crear una cuenta en GitHub: [Registrarse](https://github.com/)

### Configurar Git
```sh
git config --global user.name "Tu Nombre"
git config --global user.email tu_email@example.com
```

### Comandos esenciales de Git
```sh
git init  # Inicializar repositorio
git add .  # Agregar archivos al área de preparación
git commit -m "Primer commit"
git branch -M master  # Renombrar rama principal
git remote add origin URL_DEL_REPOSITORIO  # Vincular repositorio remoto
git push -u origin master  # Subir cambios
```

## Creación del Proyecto
### Crear la solución y las capas
```sh
dotnet new sln -n Manantial
dotnet new mvc -n Admin
dotnet new webapi -n Api
dotnet new classlib -n Core
dotnet new classlib -n Infraestructure
dotnet new classlib -n Application
ng new Client --style=css
```

### Agregar proyectos a la solución
```sh
dotnet sln add Api/Api.csproj
...
dotnet sln add Client
```

### Referencias entre capas
```sh
dotnet add Api/Api.csproj reference Application/Application.csproj
...
dotnet add Infraestructure/Infraestructure.csproj reference Core/Core.csproj
```

### Restaurar dependencias
```sh
dotnet restore
```

## Configuración de la Base de Datos
### Instalar paquetes necesarios
```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Configurar cadena de conexión (`appsettings.json`)
```json
"ConnectionStrings": {
    "CadenaConexion": "Server=TU_SERVIDOR;Initial Catalog=Manantial;User Id=sa;Password=TU_PASSWORD;Encrypt=False;TrustServerCertificate=True;"
  }
```

### Aplicar Migraciones
```sh
dotnet ef migrations add InitialCreate -p Infraestructure -s API -o Data/Migrations
dotnet ef database update
```

## Configuración del Frontend
### Instalar dependencias
```sh
npm install bootstrap
npm install @angular/common@latest
```

### Agregar Bootstrap a `angular.json`
```json
"styles": [
    "node_modules/bootstrap/dist/css/bootstrap.min.css",
    "src/styles.css"
  ]
```

## Ejecución del Proyecto
### Iniciar la API
```sh
dotnet watch run --project Api/Api.csproj
```

### Iniciar Angular
```sh
ng serve
```

## Arquitectura del Proyecto
### Capas del Sistema
1. **Capa Admin**: Interfaz para administración
2. **Capa API**: Expone servicios REST
3. **Capa Core**: Contiene entidades y lógica de negocio
4. **Capa Infrastructure**: Gestiona acceso a base de datos y servicios externos
5. **Capa Application**: Orquesta las reglas de negocio
6. **Capa Client**: Frontend desarrollado con Angular

### Principios y Patrones Implementados
- **MVC (Model-View-Controller)**
- **SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)**
- **DTOs (Data Transfer Objects)**
- **Inyección de Dependencias**

## Servicios y Controladores Destacados
- **ProductosController**: Gestiona productos
- **ErrorController**: Maneja errores
- **RepositorioGenerico**: Implementa operaciones CRUD reutilizables
- **AutoMapper**: Facilita conversión entre entidades y DTOs

## Seguridad y Manejo de Errores
- **Middleware para excepciones**
- **Autenticación y autorización con JWT (próxima implementación)**

## Contribución
1. Hacer un fork del repositorio
2. Crear una rama (`git checkout -b feature-nueva-funcionalidad`)
3. Realizar cambios y confirmarlos (`git commit -m "Descripción del cambio"`)
4. Enviar cambios al repositorio (`git push origin feature-nueva-funcionalidad`)
5. Crear un Pull Request en GitHub

## Licencia
Este proyecto está bajo la licencia MIT. Puedes usarlo y modificarlo libremente.

---
✨ **Desarrollado con ❤ por el equipo de Manantial** 🚀

