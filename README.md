# RedArbor Employee

Este proyecto esta desarrollado según los requerimientos como parte de la evaluación técnica para un puesto de Desarrollador Senior. 
Está desarrollado usando **.NET 8**, **Entity Framework** para operaciones de escritura, y **Dapper** para operaciones de lectura. 
El proyecto sigue el **patrón CQRS** (Command Query Responsibility Segregation) y aplica buenas prácticas 
como los **principios SOLID**, **Clean Code**, y **Desarrollo Guiado por Pruebas (TDD)**. 
La aplicación está dockerizada para facilitar su despliegue e incluye tanto la API como la base de datos SQL Server.

## Tabla de Contenidos

- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Uso](#uso)
- [Swagger](#url-swagger)
- [Comandos de Docker](#comandos-de-docker)
- [Postman](#Colección-de-Postman)
- [Endpoints de la API](#endpoints-de-la-api)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)

## Requisitos
- [Docker](https://www.docker.com/get-started) (para la containerización)
- [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) (para desarrollo y pruebas locales)

## Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tu-usuario/tu-repositorio.git

2. Navega al directorio del proyecto:
   ```bash
   cd RedArborAPI-main/src

## Uso

1. Inicia el proyecto con Docker Compose:
   ```bash
   docker-compose up --build

2. Para detener y eliminar los contenedores, ejecuta:
   ```bash
   docker-compose down

## Url Swagger

Puedes acceder al API en Swagger por medio de la siguiente Url [Swagger](http://localhost:9080/swagger/index.html)

## Colección de Postman

Puedes acceder a la colección de Postman [aquí](https://github.com/juanias69/RedArborAPI/blob/main/RedArborCollection.postman_collection.json).

## Endpoints de la API

### Productos:
- `GET /products`: Obtener todos los empleados.
- `GET /products/{id}`: Obtener un empleado por ID.
- `POST /products`: Crear un nuevo empleado.
- `PUT /products/{id}`: Actualizar un empleado.
- `DELETE /products/{id}`: Eliminar un empleado.

### Auth:
- `POST /login`: Generar Token de seguridad.

## Tecnologías Utilizadas

Para ejecutar las pruebas en el entorno dockerizado:
- `Docker`: Contenerización y despliegue.
- `Docker Compose`: Orquestación de múltiples contenedores.
- `Swagger`: Documentación de la API.
- `JWT`: Autenticación basada en tokens (JWT).
- `SQL`: Base de datos.




