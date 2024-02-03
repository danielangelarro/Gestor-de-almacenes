FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copia todos los archivos .csproj y restaura las dependencias
COPY src/GestorDeAlmacenes.*.sln ./
COPY src/GestorDeAlmacenes.*/*.csproj ./
RUN dotnet restore

# Copia el código fuente de todos los proyectos y compila la aplicación
COPY src/GestorDeAlmacenes.Application/ ./GestorDeAlmacenes.Application/
COPY src/GestorDeAlmacenes.Infraestructure/ ./GestorDeAlmacenes.Infraestructure/
COPY src/GestorDeAlmacenes.Domain/ ./GestorDeAlmacenes.Domain/
COPY src/GestorDeAlmacenes.API/ ./GestorDeAlmacenes.API/
RUN dotnet build src/GestorDeAlmacenes.API/GestorDeAlmacenes.API.csproj -c Release
RUN dotnet publish src/GestorDeAlmacenes.API/GestorDeAlmacenes.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorDeAlmacenes.API.dll"]