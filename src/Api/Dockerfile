FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copia la solución principal y los archivos de proyecto
COPY GestorDeAlmacenes.sln ./
COPY src/GestorDeAlmacenes.API/GestorDeAlmacenes.API.csproj ./src/GestorDeAlmacenes.API/
COPY src/GestorDeAlmacenes.Application/GestorDeAlmacenes.Application.csproj ./src/GestorDeAlmacenes.Application/
COPY src/GestorDeAlmacenes.Domain/GestorDeAlmacenes.Domain.csproj ./src/GestorDeAlmacenes.Domain/
COPY src/GestorDeAlmacenes.Infrastructure/GestorDeAlmacenes.Infrastructure.csproj ./src/GestorDeAlmacenes.Infrastructure/

# Restaura las dependencias
RUN dotnet restore

# Copia el código fuente de todos los proyectos y compila la aplicación
COPY src/GestorDeAlmacenes.Application/ ./src/GestorDeAlmacenes.Application/
COPY src/GestorDeAlmacenes.Infraestructure/ ./src/GestorDeAlmacenes.Infraestructure/
COPY src/GestorDeAlmacenes.Domain/ ./src/GestorDeAlmacenes.Domain/
COPY src/GestorDeAlmacenes.API/ ./src/GestorDeAlmacenes.API/
RUN dotnet build src/GestorDeAlmacenes.API/GestorDeAlmacenes.API.csproj -c Release
RUN dotnet publish src/GestorDeAlmacenes.API/GestorDeAlmacenes.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorDeAlmacenes.API.dll"]