FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copia el csproj y restaura las dependencias
COPY src/GestorDeAlmacenes.API/*.csproj ./
RUN dotnet restore

# Copia el código fuente del proyecto de la API y compila la aplicación
COPY src/GestorDeAlmacenes.API/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GestorDeAlmacenes.API.dll"]