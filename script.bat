@echo off
SET ProjectName=%1

:: Crear la solución centralizada
dotnet new sln -o %ProjectName%
cd .\%ProjectName%\

:: Crear los proyectos y agregarlos a la solución centralizada
mkdir src
mkdir tests
cd src
dotnet new webapi -o %ProjectName%.API
dotnet new classlib -n %ProjectName%.Application
dotnet new classlib -n %ProjectName%.Domain
dotnet new classlib -n %ProjectName%.Infrastructure

cd ..
dotnet sln add src\%ProjectName%.API\
dotnet sln add src\%ProjectName%.Application\
dotnet sln add src\%ProjectName%.Domain\
dotnet sln add src\%ProjectName%.Infrastructure\

:: Agregar referencias entre los proyectos
cd src

dotnet add .\%ProjectName%.Application\ reference .\%ProjectName%.Domain\
dotnet add .\%ProjectName%.Infrastructure\ reference .\%ProjectName%.Application\
dotnet add .\%ProjectName%.API\ reference .\%ProjectName%.Application\
dotnet add .\%ProjectName%.API\ reference .\%ProjectName%.Infrastructure\

:: Crear las carpetas dentro de cada proyecto
cd ..
mkdir src\%ProjectName%.Application\Interfaces
mkdir src\%ProjectName%.Application\\Services
mkdir src\%ProjectName%.Application\DTOs
mkdir src\%ProjectName%.Domain\Entities
mkdir src\%ProjectName%.Domain\Interfaces
mkdir src\%ProjectName%.Infrastructure\Repositories
mkdir src\%ProjectName%.Infrastructure\Persistence
mkdir tests\UnitTests

:: Agregar carpetas para la documentación y los requests HTTP
mkdir Documentation
mkdir HTTPRequests