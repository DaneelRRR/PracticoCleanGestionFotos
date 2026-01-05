# Sistema de Gestión de Fotos Inmobiliarias

Backend desarrollado con .NET implementando los principios de Clean Architecture. Este sistema automatiza la recepción, organización y gestión de fotografías de bienes inmuebles, permitiendo optimizar el flujo de trabajo entre fotógrafos y grafistas.

## Tecnologías Utilizadas

* .NET 8 / ASP.NET Core Web API
* SQL Server
* Entity Framework Core (Code First)
* AutoMapper
* Swagger

## Arquitectura de la Solución

El proyecto sigue estrictamente el patrón de Arquitectura Limpia (Clean Architecture), dividido en 4 capas desacopladas:

1.  **Domain:** Contiene las Entidades del negocio (Inmueble, Foto, Usuario, Rol) y las Interfaces de repositorio. No tiene dependencias externas.
2.  **Application:** Contiene la lógica de negocio pura (Casos de Uso), DTOs y Mapeos. Orquesta el flujo de datos entre la presentación y la infraestructura.
3.  **Infrastructure:** Implementación de acceso a datos (DbContext, Repositorios) y migraciones de Entity Framework.
4.  **WebApi:** Capa de presentación que expone los Endpoints REST y configura la inyección de dependencias.

## Funcionalidades Principales

* **Gestión de Inmuebles:** Registro y consulta de propiedades.
* **Gestión de Fotografías:** Simulación de subida de archivos a servidor local y clasificación por ambientes.
* **Selección de Favoritas:** Lógica para marcar/desmarcar fotografías seleccionadas.
* **Usuarios y Roles:** Sistema base de asignación de roles (Fotógrafo, Grafista, Admin).

## Instrucciones de Instalación

1.  Clonar el repositorio.
2.  Configurar la cadena de conexión "DefaultConnection" en el archivo appsettings.json apuntando a su instancia local de SQL Server.
3.  Abrir la consola del Administrador de Paquetes en Visual Studio.
4.  Seleccionar el proyecto "Infraestructure" como predeterminado.
5.  Ejecutar el comando: Update-Database
6.  Compilar y ejecutar el proyecto WebApi.