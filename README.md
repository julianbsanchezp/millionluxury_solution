# Million Luxury API 🚀

Proyecto técnico desarrollado con **.NET 8**, siguiendo principios de **arquitectura hexagonal**, **SOLID** y aplicando buenas prácticas modernas de desarrollo de software.  

## 🏗️ Tecnologías utilizadas
- **.NET 8 / C#**
- **ASP.NET Core Web API**
- **Entity Framework Core (InMemory / SQL Server)**
- **React (frontend - carpeta `/front`)**
- **Docker**
- **MongoDB y SQL Server**
- **xUnit y FluentAssertions** (pruebas unitarias)
- **Scrum** (metodología de trabajo colaborativo)

## 📂 Estructura del proyecto
millionluxury_solution/
│── src/
│ ├── Million.Luxury.Domain/ # Entidades y lógica de dominio
│ ├── Million.Luxury.Application/ # Casos de uso (puertos y servicios)
│ ├── Million.Luxury.Infrastructure/# Repositorios (EF Core)
│ ├── Million.Luxury.Api/ # API REST (controladores)
│ └── Million.Luxury.Tests/ # Pruebas unitarias
│── front/ # Frontend en React
│── docker/ # Configuración para despliegue
│── README.md
│── Million.Luxury.sln


## ⚙️ Cómo levantar el proyecto

### 1. Clonar el repositorio
```bash
git clone https://github.com/julianbsanchezp/millionluxury_solution.git
cd millionluxury_solution

2. Restaurar dependencias
dotnet restore

3. Compilar solución

dotnet build
4. Ejecutar la API 
dotnet run --project src/Million.Luxury.Api

La API quedará disponible en:
http://localhost:5052/swagger

5. Ejecutar pruebas unitarias
dotnet test
6. Frontend (React)
cd front
npm install
npm start

📑 Endpoints principales

POST /api/properties → Crear propiedad

GET /api/properties → Listar propiedades

PUT /api/properties/{id}/price → Cambiar precio de propiedad


